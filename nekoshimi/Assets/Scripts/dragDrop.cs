using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class dragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public static GameObject itemBeingDragged;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    
    private Vector3 startPosition;
    Transform startParent;


    private void Awake(){
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnEndDrag(PointerEventData eventData){
         itemBeingDragged = null;
        canvasGroup.blocksRaycasts = true;
        /*
        if(transform.parent == startParent){
            transform.position = startPosition;
        }
        */
        
        
    }

    public void OnDrag(PointerEventData eventData){
        //Debug.Log("ondrag");
        transform.position = eventData.position;
       // rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnBeginDrag(PointerEventData eventData){
        itemBeingDragged = gameObject;
        startPosition = transform.position;
        startParent = transform.parent;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnPointerDown(PointerEventData eventData){
        //Debug.Log("good");
    }

    
}
