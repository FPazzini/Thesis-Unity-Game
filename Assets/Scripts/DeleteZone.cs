using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DeleteZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {

    public GameObject levelManager;

    public void OnDrop(PointerEventData eventData) {
        
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null) {
            Destroy(d.placeholder);
            Destroy(d.gameObject);
            levelManager.GetComponent<LevelManagerScript>().PickCard();
        }
    }

    public void OnPointerExit(PointerEventData eventData) {
        if (eventData.pointerDrag == null)
            return;
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null) {
            d.GetComponent<CanvasGroup>().alpha = 1f;
        }
    }

    public void OnPointerEnter(PointerEventData eventData) {
        if (eventData.pointerDrag == null) {
            return;
        }
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null) {
            d.GetComponent<CanvasGroup>().alpha = 0.5f;
        }
    }
}
