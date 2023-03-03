using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class anagramsScript : MonoBehaviour
{
    //public List<Button> letters = new List<Button>();
    // Start is called before the first frame update
    [SerializeField]
    public Button[] letters;
    public Button[] slots;


    public Button done;

    [SerializeField] GameObject finishPanel;
    [SerializeField] GameObject unfinishPanel;
    
    public bool gameFinished = false;


    void Start()
    {
        finishPanel.SetActive(false);
        unfinishPanel.SetActive(false);

        //play();
        done.onClick.AddListener(()=> checkIfFinished());      
        
        
    }
   
    
    //checks if all three have "dropped"
    //what i am able to do: access the name of what was dropped.
    /*
    public void play(){
        gameContinue = false;
        if(!gameContinue){
            for(int x = 0; x < slots.Length; x++){
                if(slots[x].GetComponent<buttonSlot>().letterMatch == true){
                    gameContinue = true;
                    Debug.Log("yipeee");
                }
            }
        }
    }
    */

    //if true, check if

    public void checkIfFinished(){
        bool correct = false;
        bool complete = checkCompletion();
        if(!complete){
            correct = false;
            //Debug.Log("not fully finished");
        }
        else if(complete){
        for(int x = 0; x < slots.Length; x++){
            for(int y = 0; y < letters.Length; y++){
                if(slots[x].GetComponent<RectTransform>().anchoredPosition == letters[y].GetComponent<RectTransform>().anchoredPosition){
                    //Debug.Log("slot name: " + slots[x].name + " letters name: " + letters[y].name);
                    if(slots[x].name == letters[y].name){
                        correct = true;
                        //Debug.Log("success");
                    }
                    else{
                        correct = false;
                        x = slots.Length + 1;
                        break;
                    }
                }
            }
        }
        }

        if(correct){
           StartCoroutine(startNext()); 
            }
            
        else if (!correct){
            StartCoroutine(tryAgain());
        }

       
    }

    IEnumerator startNext(){
        finishPanel.SetActive(true);
         yield return new WaitForSeconds (1.2f);
         finishPanel.SetActive(false);
    }

    IEnumerator tryAgain(){
        unfinishPanel.SetActive(true);
        yield return new WaitForSeconds(1.2f);
        unfinishPanel.SetActive(false);

    }

    public bool checkCompletion(){
        bool com = true;
         for(int x = 0; x < letters.Length; x++){
            if(!complete(letters[x])){
                com = false;
                break;
            }
         }
         return com;
    }

    public bool complete(Button b){
        //bool bo;
        for(int y = 0; y < slots.Length; y++){
            if(b.GetComponent<RectTransform>().anchoredPosition == slots[y].GetComponent<RectTransform>().anchoredPosition){
                return true;
            }
        }
        return false;
    }
}
