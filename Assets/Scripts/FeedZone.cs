using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FeedZone : MonoBehaviour, IDropHandler, IPointerEnterHandler,  IPointerExitHandler {

    public GameObject levelManager;
    public int TIMER_DECREASE_AMOUNT;

    public void OnDrop(PointerEventData eventData) {
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null) {
            Destroy(d.placeholder);
            Destroy(d.gameObject);

            if (levelManager.GetComponent<LevelManagerScript>().GetShark().GetComponent<GreatWhiteSharkScript>().IsPartOfDiet(d.gameObject)) {
                levelManager.GetComponent<LevelManagerScript>().PlayChompingSound();
                levelManager.GetComponent<LevelManagerScript>().IncreaseScore();
                levelManager.GetComponent<LevelManagerScript>().PickCard();
            } else if (d.gameObject.CompareTag("NOSHARK")) {
                levelManager.GetComponent<LevelManagerScript>().ShowInformation(d.gameObject.name);
                levelManager.GetComponent<LevelManagerScript>().DecreaseTimer(TIMER_DECREASE_AMOUNT);
                levelManager.GetComponent<LevelManagerScript>().PickCard();
            } else {
                levelManager.GetComponent<LevelManagerScript>().DecreaseTimer(TIMER_DECREASE_AMOUNT);
                levelManager.GetComponent<LevelManagerScript>().PickCard();
            }
            
        }
    }

    public void OnPointerExit(PointerEventData eventData) {
        
    }

    public void OnPointerEnter(PointerEventData eventData) { 
    }

}
