using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class ScoreAndTimer : MonoBehaviour
{
    [SerializeField] PhotonView myPV;
    [SerializeField] GameObject WinningPanel;
    public TMP_Text Timertxt;

    //public MonoBehaviour countDown;

    private PlayerData[] playerDataList = new PlayerData[4];

    int currentTime = 0;
    public int startingTime = 45;

   void Start(){
        currentTime = startingTime;

   }
    void Update(){
        if(currentTime > 0){
        currentTime -= 1;
        }
        else{
            currentTime = 0;
        }

        if(WinningPanel.activeSelf){
            int finishTime  = currentTime;
            int score = ConvertTimeToScore(finishTime);
            myPV.RPC("addScore", RpcTarget.All, score);
        }
    }

    public int ConvertTimeToScore(int time){
        return (time+30)*10;
    }

    [PunRPC]
    public void addScore(int newScore){
        playerDataList[(PhotonNetwork.LocalPlayer.ActorNumber)%4].setScore(newScore);
    }
/*
    [PunRPC]
    public void SceneEnd(){

    }




    [PunRPC]
    public void ConvertScoreToRank(int time){

    }
    */
}
