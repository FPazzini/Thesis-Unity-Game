using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreatWhiteSharkScript :SharkBase {

    public GreatWhiteSharkScript(int hp) : base(hp) {}
    public List<GameObject> diet;

    public bool IsPartOfDiet (GameObject food) {
        foreach(GameObject g in diet) {
            Debug.Log(g.tag);
        }
        foreach (GameObject go in diet) {
            if (go.tag.Equals(food.tag)) {
                return true;
            }
        }
        return false;
    }

    public List<GameObject> GetDiet () {
        return this.diet;
    }
}
