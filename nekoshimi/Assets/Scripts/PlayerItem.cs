using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class PlayerItem : MonoBehaviourPunCallbacks
{
    public TMP_Text playerName;
    public Image backgroundImage;
    public GameObject leftArrowButton;
    public GameObject rightArrowButton;

    public TMP_Text readyText;
    public bool ready = false;
    public int playerNumber;

    ExitGames.Client.Photon.Hashtable playerProperties = new ExitGames.Client.Photon.Hashtable();
    public Image playerAvatar;
    public Sprite[] avatars;

    Player player;


    //public PhotonView photonView;

    private void Start()
    {
        backgroundImage = GetComponent<Image>();
    }

    public void SetPlayerInfo(Player _player)
    {
        playerName.text = _player.NickName;
        player = _player;
        UpdatePlayerItem(player);
    }

    //only shows in my screen. 
    public void ApplyLocalChanges()
    {
        leftArrowButton.SetActive(true);
        rightArrowButton.SetActive(true);
    }

    public void OnClickLeftArrow()
    {   
        if((int)playerProperties["playerAvatar"] == 0)
        {
            playerProperties["playerAvatar"] = avatars.Length - 1;
        } else{
            playerProperties["playerAvatar"] = (int)playerProperties["playerAvatar"] - 1;
        }
        PhotonNetwork.SetPlayerCustomProperties(playerProperties);
    }
    public void OnClickRightArrow()
    {   
        if((int)playerProperties["playerAvatar"] == avatars.Length - 1)
        {
            playerProperties["playerAvatar"] = 0;
        } else{
            playerProperties["playerAvatar"] = (int)playerProperties["playerAvatar"] + 1;
        }
        PhotonNetwork.SetPlayerCustomProperties(playerProperties);
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        if(player == targetPlayer)
        {
            UpdatePlayerItem(targetPlayer);
        }
    }

    void UpdatePlayerItem(Player player)
    {
        if(player.CustomProperties.ContainsKey("playerAvatar"))
        {
            playerAvatar.sprite = avatars[(int)player.CustomProperties["playerAvatar"]];
            playerProperties["playerAvatar"] = (int)player.CustomProperties["playerAvatar"];
        } else{
            playerProperties["playerAvatar"] = 0;
        }
    }


    public void changeReadySatus(){
        ready = !ready;
        displayReadyStatus();
    }

    public void displayReadyStatus(){
        if(ready){
            readyText.color = Color.green;
        }
        else{
            readyText.color = Color.gray;
        }
    }

    /*
    [PunRPC]
    public void displayReadyStatusRPC(){
        if(ready){
            readyText.color = Color.green;
        }
        else{
            readyText.color = Color.gray;
        }
    }

    [PunRPC]
    void changeReadySatusRPC(){
        ready = !ready;
        displayReadyStatus();
    }
    */

    public void setPlayerNumber(int k){
        playerNumber = k;
    }
}
