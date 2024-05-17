using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
public class OnGame : MonoBehaviourPunCallbacks
{
    public Transform DadSpawnPoint;
    public Transform SonSpawnPoint;

    private void Awake() => PhotonNetwork.AutomaticallySyncScene = true;
    void Start()
    {
        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.ConnectUsingSettings();
        }
        else
        {
            SpawnPlayer();
        }
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Photon Master Server");
        PhotonNetwork.JoinLobby();
    }
    public override void OnJoinedLobby()
    {
        PhotonNetwork.JoinOrCreateRoom("Loby", new RoomOptions { MaxPlayers = 2, IsOpen = true, IsVisible = true }, TypedLobby.Default);
    }
    public override void OnJoinedRoom()
    {
        Debug.Log("OnJoinedRoom");

        SpawnPlayer();

    }

    void SpawnPlayer()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Instantiate("PlayerDad", DadSpawnPoint.position, DadSpawnPoint.rotation);
            Debug.Log("Master client connected to room as player dad");
        }
        else
        {
            PhotonNetwork.Instantiate("PlayerSon", SonSpawnPoint.position, SonSpawnPoint.rotation);
            Debug.Log("Client connected to room as player son");
        }
    }
}
