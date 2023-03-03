using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public TMP_InputField roomInputField;
    public GameObject lobbyPanel;
    public GameObject createPanel;
    public GameObject roomPanel;
    public TMP_Text roomName;

    public RoomItem roomItemPrefab;
    List<RoomItem> roomItemsList = new List<RoomItem>();
    public Transform contentObject;

    public float timeBetweenUpdates = 1.5f;
    float nextUpdateTime;

    public List<PlayerItem> playerItemsList = new List<PlayerItem>();
    public PlayerItem playerItemPrefab;
    public Transform playerItemParent;

    public GameObject playButton;
    public GameObject readyButton;

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.JoinLobby();
    }
    public void OnClickCreate(){
        if(roomInputField.text.Length >=1 ){
            PhotonNetwork.CreateRoom(roomInputField.text, new RoomOptions(){MaxPlayers = 4, BroadcastPropsChangeToAll = true});
        }
    }
    public override void OnJoinedRoom()
    {
        lobbyPanel.SetActive(false);
        createPanel.SetActive(false);
        roomPanel.SetActive(true);
        roomName.text = PhotonNetwork.CurrentRoom.Name;
        UpdatePlayerList();
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        if(Time.time >= nextUpdateTime){
            UpdateRoomList(roomList);
            nextUpdateTime = Time.time + timeBetweenUpdates;
        }
    }

    void UpdateRoomList(List<RoomInfo> list)
    {
        foreach(RoomItem item in roomItemsList)
        {
            Destroy(item.gameObject);
        }
        roomItemsList.Clear();

        foreach(RoomInfo room in list)
        {
           RoomItem newRoom = Instantiate(roomItemPrefab, contentObject);
           newRoom.SetRoomName(room.Name);
           roomItemsList.Add(newRoom);
        }
    }

    public void JoinRoom(string roomName){
        PhotonNetwork.JoinRoom(roomName);
    }

    public void OnClickLeaveRoom(){
        PhotonNetwork.LeaveRoom();
    }
    public override void OnLeftRoom()
    {
        lobbyPanel.SetActive(true);
        createPanel.SetActive(false);
        roomPanel.SetActive(false);
    }

    public override void OnConnectedToMaster(){
        PhotonNetwork.JoinLobby();
    }

    void UpdatePlayerList()
    {
        foreach(PlayerItem item in playerItemsList)
        {
            Destroy(item.gameObject);
        }
        playerItemsList.Clear();

        if(PhotonNetwork.CurrentRoom == null)
        {
            return;
        }

        int k =0;

        //Loops through all of the players in the room, int is ID
        foreach(KeyValuePair<int, Player> player in PhotonNetwork.CurrentRoom.Players)
        {
            PlayerItem newPlayerItem = Instantiate(playerItemPrefab, playerItemParent);
            newPlayerItem.SetPlayerInfo(player.Value);

            //checking if this is player me?
            if(player.Value == PhotonNetwork.LocalPlayer)
            {
                newPlayerItem.ApplyLocalChanges();
                if(player.Value.IsMasterClient){
                    playButton.SetActive(true);
                    newPlayerItem.ready = true;
                    newPlayerItem.displayReadyStatus();
                }
                else{
                    readyButton.SetActive(true);
                }
                newPlayerItem.setPlayerNumber(k);
            }

            playerItemsList.Add(newPlayerItem);
            k++;
        }


    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        UpdatePlayerList();   
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        UpdatePlayerList();
    }

    public void Update()
    {
        if(PhotonNetwork.IsMasterClient /*&& PhotonNetwork.CurrentRoom.PlayerCount >= 2*/)
        {
            playButton.SetActive(true);
        }
        else{
            playButton.SetActive(false);
        }
    }

    public void OnClickPlayButton()
    {
        foreach(PlayerItem item in playerItemsList)
        {
            if(!item.ready){
                return;
            }
        }
        PhotonNetwork.LoadLevel("Round1");
    }

    public void OnClickReadyButton()
    {
        int index = PhotonNetwork.LocalPlayer.ActorNumber;
        PlayerItem item = playerItemsList[index-1];
        item.changeReadySatus();

        foreach(PlayerItem item2 in playerItemsList)
        {
            item2.displayReadyStatus();
        }
    }

}