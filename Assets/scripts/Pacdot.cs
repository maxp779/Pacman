using UnityEngine;
using System.Collections;

public class Pacdot : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D otherObject)
    {
        if(otherObject.name == "pacman")
        {
            Destroy(this.gameObject);
            CurrentGameState.increaseScore();
        }
    }
}
