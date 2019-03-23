using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DeckManager : MonoBehaviour {

    public GameObject[] cardsTemplates;
    private GameObject[] deck;
    private static int NUMBER_OF_CARDS = 1000;

    System.Random random = new System.Random();

    public void Start () {
        deck = new GameObject[NUMBER_OF_CARDS];
    }

    public void PrepareDeck() {
        // Indice casuale che mi serve per ottenere una carta randomica dai templates
        int index;
        // Lista che conterrà il deck che verrà poi riversato nell'array 
        List<GameObject> newDeck = new List<GameObject>();
        // Oggetto temporaneo che mi salva la carta pickata randomicamente
        GameObject temp;
        // Ciclo finché il numero di carte nel deck temporaneo non ha >= 40 carte, a quel punto esco
        while (newDeck.Count < NUMBER_OF_CARDS) {
            // Picko un indice randomico dai templates
            index = random.Next(0, cardsTemplates.Length);
            // Mi salvo la carta corrispondente all'indice randomico
            temp = cardsTemplates[index];

            // Aggiungo la carta pickata nella lista temporanea
            newDeck.Add(temp);
        }
        // Copio la lista nell'array che rappresenta il deck
        deck = newDeck.ToArray();
    }

    public void ShuffleDeck() {
        for (int i = deck.Length - 1; i > 0; i--) {
            int index = random.Next(i - 1);
            // Simple swap
            GameObject temp = deck[index];
            deck[index] = deck[i];
            deck[i] = temp;
        }
    }

    public void InstantiateDeck (Transform hand, int numOfCardsToHold) {
        GameObject cardInHand;
        GameObject temp;
        for (int i = 0; i < numOfCardsToHold; i++) {
            temp = deck[i];
            cardInHand = Instantiate(temp) as GameObject;
            cardInHand.name = temp.name;
            cardInHand.transform.SetParent(hand);
        }
    }

    public void Update() {
    }

    public GameObject[] GetDeck () {
        return this.deck;
    }

    public bool PickUpCard (Transform hand) {
        if (deck.Length > 0) {
            GameObject pickedCard = GetNextCard();
            GameObject nextCard = Instantiate(pickedCard) as GameObject;
            nextCard.name = pickedCard.name;
            nextCard.transform.SetParent(hand);
            nextCard.GetComponent<RectTransform>().localScale = new Vector3(1.44671f, 1.44671f, 1.44671f);
            // Ritorno true per indicare al level manager che ho pescato una carta con successo, il che significa che ho almeno una carta
            // nel deck.
            return true;
        }
        // Ritorno false per indicare al level manager che non sono riuscito a pescare una carta in quanto non ci sono più carte disponibili
        // nel deck, e di conseguenza devo mostrare il fine partita.
        return false;
    }
    
    public GameObject GetNextCard () {
        List<GameObject> deckList = deck.ToList<GameObject>();
        GameObject nextCard = deckList.First<GameObject>();
        deckList.RemoveAt(0);
        deck = deckList.ToArray();
        return nextCard;
    }
    

}
