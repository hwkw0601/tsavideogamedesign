using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Photon.Pun;
public class SpawnerSpawner : MonoBehaviour
{
    public GameObject spawner;
    public Transform[] spawnPoints;

    private int actorNum;
    // Start is called before the first frame update
    void Start()
    {
        actorNum = (PhotonNetwork.LocalPlayer.ActorNumber)%4;
        Transform spawnPoint = spawnPoints[actorNum-1];
        PhotonNetwork.Instantiate(spawner.name, spawnPoint.position, Quaternion.identity);
    }

}
