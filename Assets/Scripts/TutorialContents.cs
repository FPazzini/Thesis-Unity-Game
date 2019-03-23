using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialContents : MonoBehaviour
{
    public static TutorialContents NewInstance () {
        return new TutorialContents();
    }

    public static TitleBodyContents GetContents (string buttonTag) {
        switch(buttonTag) {
            case "FeedingArea":
                return new TitleBodyContents("Area di feeding", "Trascina le carte in questa zona per cibare lo squalo! Attenzione però: se la preda non sara' gradita, perderai dei secondi preziosi!");
            case "TimerArea":
                return new TitleBodyContents("Timer", "Tieni d'occhio questa zona per vedere quanto tempo ti rimane!");
            case "ScoreArea":
                return new TitleBodyContents("Punteggio", "Qui troverai il tuo punteggio. Piu' alto e', meglio e'!");
            case "DiscardArea":
                return new TitleBodyContents("Area di scarto", "Se pensi che un certo animale non faccia parte della dieta dello squalo con cui giochi, trascina qui la carta e sara' scartata!");
            case "JawArea":
                return new TitleBodyContents("Mascella", "Qui potrai manipolare la mascella dello squalo con cui giochi e scoprirne i dettagli piu' nascosti!");
            case "HandArea":
                return new TitleBodyContents("Mano", "In questa zona potrai vedere le carte che peschi. Puoi trascinarle nella zona di scarto o giocarle, ma anche riordinarle nella mano stessa.");
            case "SharkArea":
                return new TitleBodyContents("Squalo", "Questo sara' lo squalo con cui deciderai di giocare!");
            default:
                return new TitleBodyContents("", "");
        }
    }
    
    public class TitleBodyContents {
        string title;
        string body;

        public TitleBodyContents(string title, string body) {
            this.title = title;
            this.body = body;
        }
        
        public string GetTitle () {
            return this.title;
        }

        public string GetBody () {
            return this.body;
        }
    }
}
