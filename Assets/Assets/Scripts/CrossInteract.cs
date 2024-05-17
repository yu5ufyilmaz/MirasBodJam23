using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CrossInteract : MonoBehaviour
{
    public LayerMask raycastLayer;
    public Image collectImage;

    private void Start()
    {
        collectImage.enabled = false;
    }
    void Update()
    {

        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenter);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, raycastLayer))
        {
            GameObject hitObject = hit.collider.gameObject;

            if (hitObject != null)
            {
                ImageTurnOnOff();
                // mouse if(ınput.GetButtonDown("Interact"))
                {
                    collectImage.enabled = true;
                }
                EvntManager.TriggerEvent("CrossInteract", hitObject);
            }



        }
    }

    private void ImageTurnOnOff()
    {
        if (collectImage.enabled)
        {
            collectImage.enabled = false;
        }
        else
        {
            collectImage.enabled = true;
        }
    }
}
