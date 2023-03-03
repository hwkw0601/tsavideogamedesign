using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testScript : MonoBehaviour
{
    [SerializeField]
    public Button butt;
    [SerializeField]
    //public Button two;
    //public Sprite sp;
    public List<Sprite> sps = new List<Sprite>();

    // Start is called before the first frame update
    void Start()
    {   
        butt.GetComponent<Button>().image.sprite = sps[0];
        start1();
        //lateUpdate();
       //butt.onClick.AddListener(()=> change()); 
    }


    public void start1(){
        butt.GetComponent<Button>().onClick.AddListener(()=> change());
    }


    public void change(){
        /*
        two.GetComponent<Button>().image.overrideSprite = sp;
        butt = two;
        butt.GetComponent<Button>().image.overrideSprite = sp;
        */
        StartCoroutine(animate());
        

        
    }

     IEnumerator animate(){
        int s = sps.Count;
        butt.image.sprite = sps[1];
        for(int x = 0; x < s; x++){
            butt.image.sprite = sps[x];
            yield return new WaitForSeconds (.1f);
            Debug.Log("yup");
        }
        Debug.Log("good");
     }

    
}
