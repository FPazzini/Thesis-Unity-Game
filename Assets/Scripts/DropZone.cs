﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {
    public void OnDrop(PointerEventData eventData) {
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null) {
            d.parentToReturnTo = this.transform;
        }
    }

    public void OnPointerExit(PointerEventData eventData) {
        if (eventData.pointerDrag == null)
            return;
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null && d.placeholderParent == this.transform) {
            d.placeholderParent = d.parentToReturnTo;
        }
    }

    public void OnPointerEnter(PointerEventData eventData) {
        //Debug.Log(eventData.pointerDrag.name + "OnDrop Enter");
        if (eventData.pointerDrag == null) {
            return;
        }
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null) {
            d.placeholderParent = this.transform;
        }
    }
    
}
