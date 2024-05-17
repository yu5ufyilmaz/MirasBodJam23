using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using TMPro;
using Unity.VisualScripting;
public class Loby : MonoBehaviourPunCallbacks
{
    [SerializeField] private byte maxPlayers = 2;

    [SerializeField] private TMP_Text StatuText;

    private void Awake() => PhotonNetwork.AutomaticallySyncScene = true;
    private void Start() => PhotonNetwork.ConnectUsingSettings();

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Photon Master Server");
        PhotonNetwork.JoinLobby();
    }
        public override void OnJoinedLobby()
    {
        StatuText.text = "You are on the loby you can join a room now";
    }
    public void ConnectRoom(string roomName)
    {
        PhotonNetwork.JoinOrCreateRoom(roomName, new Photon.Realtime.RoomOptions { MaxPlayers = maxPlayers }, null, null);
    }
    
    public override void OnJoinedRoom()
    {
        Debug.Log("Joined a room");
        Debug.Log("Room name: " + PhotonNetwork.CurrentRoom.Name + " bağlandı");
        string roomName = PhotonNetwork.CurrentRoom.Name;
        int roomPlayerCount = PhotonNetwork.CurrentRoom.PlayerCount;
        Debug.Log(roomName + " " + roomPlayerCount);
        StartCoroutine(CheckRoom());
    }

    public IEnumerator CheckRoom()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
            {
                StatuText.text = "Room is ok. Game will be start on 3 seconds";
                Invoke(nameof(LoadLevel),3f);
                break;
            }
        }
    }

    public void LoadLevel()
    {
        PhotonNetwork.LoadLevel("Loby");
    }
}
