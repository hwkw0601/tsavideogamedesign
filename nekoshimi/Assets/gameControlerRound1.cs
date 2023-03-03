using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class gameControlerRound1 : MonoBehaviour
{
    public GameObject game;
    public List<Button> btns = new List<Button>();
    public List<Button> answerBtns = new List<Button>();
    public Button startPipe;
    public Button endPipe;
    [SerializeField] GameObject WinningPanel;

    public Sprite[] gameAnim = new Sprite[9];

    float[] rotations = {0, 90, 180, 270};
    // Start is called before the first frame update
    void Start()
    {
        Shuffle(btns);
        AddListeners();
    }

    // Update is called once per frame
    void Update()
    {
    }

    //shuffle the buttons
    void Shuffle(List<Button> list){

        for(int i = 0; i < list.Count; i++){
            Button temp = list[i];

            //rotate by random degrees
            int rand = Random.Range(0, rotations.Length);
            temp.transform.Rotate(new Vector3(0, 0, -90*rand));
        }
    }
   
    public void changeRotation(Button btn){
            btn.transform.Rotate(new Vector3(0, 0, -90));
    }

    public void playAnimation(){
        StartCoroutine(valveAnim(startPipe));
    }

    void AddListeners(){
        foreach(Button btn in btns){
            btn.onClick.AddListener(()=> changeRotation(btn));
        }
    }



    public void Check(){
        Debug.Log("Check.");
        for(int k=0; k<btns.Count; k++){
            if(!(k==1 || k==2 || k==5 || k==6)){
                if(RotationToNumber(btns[k]) != RotationToNumber(answerBtns[k])){
                Debug.Log(k);
                return;
                }
            } 
        }

        Debug.Log("You Win!");
        WinningPanel.SetActive(true);
    }


    private int RotationToNumber(Button but){
        if(but.transform.rotation.z == 0){
            return 0;
        }
        else if(but.transform.rotation.z==-90){
            return 1;
        }
        else if(but.transform.rotation.z == 180 || but.transform.rotation.z==-180){
            return 2;
        }
        else{
            return 3;
        }
    }


    IEnumerator valveAnim(Button b){
        for(int x = 0; x < 6; x++){
            b.image.sprite = gameAnim[x];
            yield return new WaitForSeconds (.1f);
        }
        
     }

}
