using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Runtime.InteropServices;
public class DragDrop : MonoBehaviour,IPointerDownHandler,IBeginDragHandler,IEndDragHandler,IDragHandler
{
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    [SerializeField] private RectTransform mouse;
    private Vector2 returnPoint;
    private CanvasGroup canvasGroup;

    bool isEndDrag;
    bool isAttack;


    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        isEndDrag = false;
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.4f;
        canvasGroup.blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition = eventData.position;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if(isEndDrag == true)
        {
            rectTransform.anchoredPosition = returnPoint;
        }
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true ;
        isEndDrag = false;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        returnPoint = rectTransform.anchoredPosition;
        isEndDrag = false;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Item")
        {
            isEndDrag = true ;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Item")
        {
            isEndDrag = false;
        }
    }
}
