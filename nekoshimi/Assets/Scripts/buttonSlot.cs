using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class buttonSlot : MonoBehaviour, IDropHandler
{
    //public bool letterMatch = false;
    public string letterName;
    //public bool dropActivated = false;
    
    public void OnDrop(PointerEventData eventData){
        //dropActivated = true;
        ///Debug.Log("on drop activated");

        if(eventData.pointerDrag!= null){
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            letterName = eventData.pointerDrag.name;
            /*
            if(eventData.pointerDrag.name == gameObject.name){
                letterMatch = true;
                Debug.Log(eventData.pointerDrag.name + " game: "+ gameObject.name);
            }
            else{
                letterMatch = false;
                Debug.Log("false: " + eventData.pointerDrag.name);
            }
            */
        }


    }
    
}
