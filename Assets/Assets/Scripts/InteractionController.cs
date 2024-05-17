using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.InputSystem;

public class CameraSwitch : MonoBehaviourPunCallbacks
{
    public Camera firstCamera;    // İlk kamera
    public Camera secondCamera;   // İkinci kamera

    private Camera currentCamera; // Şu anki kamera

    private bool inTriggerZone = false; // Trigger bölgesinde mi kontrolü
    PhotonView pw;
    public PlayerInput PI;
    public TMP_Text interactText; // UI metni
    [SerializeField] private Transform target;

    private void Start()
    {
        currentCamera = firstCamera; // İlk başta birinci kamerayı kullanıyoruz
        secondCamera.enabled = false; // İkinci kamerayı devre dışı bırak
        pw = GetComponent<PhotonView>();
        // Başlangıçta metni gizle
        interactText.enabled = false;
        secondCamera.transform.position = firstCamera.transform.position;
        secondCamera.transform.rotation = firstCamera.transform.rotation;

    }

    private void Update()
    {
        if (PhotonNetwork.IsMasterClient)
        {

            if (inTriggerZone)
            {
                // Trigger bölgesindeyken "E" tuşuna basılabilir
                interactText.enabled = true;

                if (Input.GetKeyDown(KeyCode.F))
                {
                    PI = GameObject.Find("PlayerDad(Clone)").GetComponent<PlayerInput>();
                    secondCamera.transform.position = firstCamera.transform.position;
                    secondCamera.transform.rotation = firstCamera.transform.rotation;
                    SwitchCamera(); // E tuşuna basıldığında kameraları değiştir
                }
            }
            else
            {
                // Trigger bölgesinde değilse metni gizle
                interactText.enabled = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            inTriggerZone = true; // Trigger bölgesine girdiğinde
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inTriggerZone = false; // Trigger bölgesinden çıktığında
        }
    }

    private void SwitchCamera()
    {
        EvntManager.TriggerEvent("Stop");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        if (PI.enabled == false)
        {
            PI.enabled = true;
        }
        else
            PI.enabled = false;
        currentCamera.enabled = false; // Şu anki kamerayı kapat
        if (currentCamera == firstCamera)
        {
            currentCamera = secondCamera;
        }
        else
        {
            currentCamera = firstCamera;
            Cursor.visible = false;
        }
        // Kamera geçişini animasyonla yap
        currentCamera.enabled = true;
        currentCamera.transform.DOMove(target.position, 1.0f);
    }
}
