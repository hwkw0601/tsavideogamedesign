using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class AllPlayerGameManager : MonoBehaviour
{

    //[SerializeField] private GameObject openCertainTransition;
    //[SerializeField] private GameObject closeCertainTransition;

    // Start is called before the first frame update
    void Start()
    {
        //openCertainTransition.SetActive(true);
        //FunctionTimer.Create(DisableStartingSceneTransition, timer: 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void DisableStartingSceneTransition(){
        //openCertainTransition.SetActive(false);
    }

    private static void goToNextScene(){
        //closeCertainTransition.SetActive(true);
       //FunctionTimer.Create(LoadNextLevel, timer:1.5f);
    }

    private static void LoadNextLevel(){
        //PhotonNetwork.LoadLevel(nextLevelName);
    }

}
