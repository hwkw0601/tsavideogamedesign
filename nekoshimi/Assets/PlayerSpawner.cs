using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject[] playerPrefabs;
    public Transform[] spawnPoints;
    public PhotonView photonView;

    private int actorNum;

    public GameObject PlayerCamera;

    private void Start()
    {
        if(photonView.IsMine)
        {
            PlayerCamera.SetActive(true);
            Transform spawnPoint = spawnPoints[0];
            if(!PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("playerAvatar"))
            {
                PhotonNetwork.LocalPlayer.CustomProperties["playerAvatar"] = 0;
            } 
            GameObject playerToSpawn = playerPrefabs[(int)PhotonNetwork.LocalPlayer.CustomProperties["playerAvatar"]];
            PhotonNetwork.Instantiate(playerToSpawn.name, spawnPoint.position, Quaternion.identity);
        }
        else{
            PlayerCamera.SetActive(false);
        }
    }
}
