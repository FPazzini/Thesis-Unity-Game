using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialButtonsScript : MonoBehaviour
{
    public GameObject tutorialManager;

    public void ManageExplanationContent () {
        TutorialContents.TitleBodyContents tbc = TutorialContents.GetContents(gameObject.tag);
        tutorialManager.GetComponent<TutorialManagerScript>().ManageExplanationPanelVisibility(true);
        tutorialManager.GetComponent<TutorialManagerScript>().SetTitle(tbc.GetTitle());
        tutorialManager.GetComponent<TutorialManagerScript>().SetBody(tbc.GetBody());
    }

}
