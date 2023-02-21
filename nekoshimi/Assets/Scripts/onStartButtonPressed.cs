using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class onStartButtonPressed : MonoBehaviour
{
    public void getLoadingScene()
    {
        SceneManager.LoadScene("Loading");
    }
}
