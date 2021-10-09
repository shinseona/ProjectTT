using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class itemSlot : MonoBehaviour,IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.position != null)
        {
            Debug.Log(eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition);
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        }
    }
}
