using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PhotonLevelLoader : MonoBehaviour
{
    public void OpenLevel(string levelname)
    {
        PhotonNetwork.LoadLevel(levelname);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            OpenLevel("Level2");
        }
    }
}
