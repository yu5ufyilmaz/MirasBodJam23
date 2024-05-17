using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UIElements;

public class RotateObjects : MonoBehaviourPunCallbacks
{
    public bool OnRotate = false;
    public float rotationSpeed = 100f;
    private void OnMouseDown()
    {
        if (OnRotate == true)
        {
            OnRotate = false;
            this.GetComponent<Outline>().enabled = false;

        }
        else
        {
            OnRotate = true;
            this.GetComponent<Outline>().enabled = true;
        }
    }
    private void Update()
    {
        Rotatee();
    }
    private void Rotatee()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            if (OnRotate)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
                }
                else if (Input.GetKey(KeyCode.Q))
                {
                    transform.Rotate(Vector3.forward, -rotationSpeed * Time.deltaTime);
                }
            }
        }
    }




}
