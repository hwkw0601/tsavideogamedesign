using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class countDown : MonoBehaviour
{
    public int score;

   float currentTime = 0;

   [SerializeField] TMP_Text txt;
   [SerializeField] GameObject WinningPanel;
   public float startingTime;

   void Start(){
        currentTime = startingTime;

   }

    void Update(){
        if(!WinningPanel.activeSelf){
        currentTime -= 1* Time.deltaTime;
        txt.text = currentTime.ToString("0.");
        }
        else{
            //score calculations
        }
    }

}
