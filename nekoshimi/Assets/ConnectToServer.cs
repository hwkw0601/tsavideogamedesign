using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ConnectToServer : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
}
