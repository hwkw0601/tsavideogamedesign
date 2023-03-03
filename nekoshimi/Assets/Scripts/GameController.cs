using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private Sprite bgImage;

    public Sprite[] puzzles;

    //animation 2d array
    public Sprite[] sashimi1;
    public Sprite[] sashimi2;
    public Sprite[] sashimi3;
    public Sprite[] sashimi4;
    public Sprite[] sashimi5;
    public Sprite[] sashimi6;

    public Sprite[][] anim = new Sprite[6][];

    public List<Sprite> gamePuzzles = new List<Sprite>();
    public Sprite[][] gameAnim = new Sprite[12][];

    public List<Button> btns = new List<Button>();

    private int countGuesses, countCorrectGuesses, gameGuesses;

    private int firstGuessIndex, secondGuessIndex;
    private string firstGuessPuzzle, secondGuessPuzzle;

    private bool firstGuess, secondGuess;

    [SerializeField] GameObject WinningPanel;

    void Start(){
        WinningPanel.SetActive(false);
        GetButtons();
        addAnim();
        AddListeners();
        AddGamePuzzles();
        Shuffle(gamePuzzles, gameAnim);
    }

    void addAnim(){
        anim[0] = sashimi1;
        anim[1] = sashimi2;
        anim[2] = sashimi3;
        anim[3] = sashimi4;
        anim[4] = sashimi5;
        anim[5] = sashimi6;
    }
    
    void AddGamePuzzles(){
        int looper = btns.Count;
        int index = 0;

        for(int i = 0; i < looper; i++){
            if(index == looper/2){
                index = 0;
            }

            gamePuzzles.Add(puzzles[index]);
            gameAnim[i] = anim[index];
            index++;
        }
    }
    

    void GetButtons(){
        GameObject[] objects = GameObject.FindGameObjectsWithTag("PuzzleButton");

        for(int i = 0; i < objects.Length; i++){
            btns.Add(objects[i].GetComponent<Button>());
            btns[i].image.sprite = sashimi1[0];
        }
    }

    //animation methods

     IEnumerator flipOver(Button b, int idx){
        //int s = anim[idx].Length;
        //b.image.sprite = sps[1];
        for(int x = 0; x < 6; x++){
            b.image.sprite = gameAnim[idx][x];
            yield return new WaitForSeconds (.1f);
        }
        
     }

     IEnumerator flipBack(Button b, int idx){
        //int s = anim[idx].Length;
        //b.image.sprite = sps[1];
        for(int x = 5; x >= 0; x--){
            b.image.sprite = gameAnim[idx][x];
            yield return new WaitForSeconds (.1f);
        }
        
     }

    void AddListeners(){
        foreach(Button btn in btns){
            btn.onClick.AddListener(()=> PickAPuzzle());
        }
    }

    public void PickAPuzzle(){

        if(!firstGuess){
            firstGuess = true;
            firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            firstGuessPuzzle = gamePuzzles[firstGuessIndex].name;
            btns[firstGuessIndex].interactable = false;
            StartCoroutine(flipOver(btns[firstGuessIndex], firstGuessIndex));
            //btns[firstGuessIndex].image.sprite = gamePuzzles[firstGuessIndex];
        }

        else if (!secondGuess){
            secondGuess = true;
            secondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            secondGuessPuzzle = gamePuzzles[secondGuessIndex].name;
            btns[secondGuessIndex].interactable = false;
            //btns[secondGuessIndex].image.sprite = gamePuzzles[secondGuessIndex];
            StartCoroutine(flipOver(btns[secondGuessIndex], secondGuessIndex));
            StartCoroutine(CheckIfThePuzzlesMatch());
        }
    }

    IEnumerator CheckIfThePuzzlesMatch(){
        yield return new WaitForSeconds (.7f);

        if(firstGuessPuzzle == secondGuessPuzzle){
            yield return new WaitForSeconds (.2f);

        btns[firstGuessIndex].interactable = false;
        btns[secondGuessIndex].interactable = false;

        //make them disappear after correct guess
        /*
        btns[firstGuessIndex].image.color = new Color(0, 0, 0, 0);
        btns[secondGuessIndex].image.color = new Color(0, 0, 0, 0);
        */
            CheckIfTheGameIsFinished();
        }
        else{
            StartCoroutine(flipBack(btns[firstGuessIndex], firstGuessIndex));
             StartCoroutine(flipBack(btns[secondGuessIndex], secondGuessIndex));
              btns[firstGuessIndex].interactable = true;
               btns[secondGuessIndex].interactable = true;
            //btns[firstGuessIndex].image.sprite = sashimi1[0];
            //btns[secondGuessIndex].image.sprite = sashimi1[0];
            yield return new WaitForSeconds (.1f);
        }

        

        firstGuess = secondGuess = false;
    }

    void CheckIfTheGameIsFinished(){
        countCorrectGuesses++;
        //gameGuesses = (btns.Count)/2;
        if(countCorrectGuesses == (btns.Count)/2){
            WinningPanel.SetActive(true);
            //Debug.Log("Game finished");
        }
    }

    void Shuffle(List<Sprite> list, Sprite[][] sp){

        for(int i = 0; i < list.Count; i++){
            Sprite temp = list[i];
            Sprite[] tempAni = sp[i];
            int randomIndex = Random.Range(0, list.Count);
            list[i] = list[randomIndex];
            sp[i] = sp[randomIndex];
            list[randomIndex] = temp;
            sp[randomIndex] = tempAni;
        }

    }

}
