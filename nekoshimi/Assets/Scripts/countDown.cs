using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class NewBehaviourScript : MonoBehaviour
{
   public float currentTime = 0;
   float startingTime = 45f;

   [SerializeField] Text txt;
    [SerializeField] GameObject WinningPanel;
   void Start(){
        currentTime = startingTime;

   }

    void Update(){
        timer();
        //else{
          //  currentTime = 0;
        //}
        //p1rint(currentTime);
    }

    void timer(){
        if(currentTime == 0){
        //if(txt.text.Equals(0)){
            Debug.Log("time done!");
            WinningPanel.SetActive(true);
        }
        else if(currentTime > 0){
        currentTime -= 1* Time.deltaTime;
        //Debug.Log(currentTime);
        txt.text = currentTime.ToString();
        }
    }

}
