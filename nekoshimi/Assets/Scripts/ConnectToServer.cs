using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ConnectToServer : MonoBehaviourPunCallbacks
{

    public TMP_InputField usernameInput;
    public GameObject loadingScreen;
    // Start is called before the first frame update
    public void OnClickConnect(){
        if(usernameInput.text.Length >= 1 )
        {
            loadingScreen.SetActive(true);
            PhotonNetwork.NickName = usernameInput.text;
            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public override void OnConnectedToMaster()
    {
        SceneManager.LoadScene("Lobby");
    }
}   
