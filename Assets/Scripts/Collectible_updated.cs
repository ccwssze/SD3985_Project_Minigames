using Cainos.PixelArtTopDown_Basic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible_updated : MonoBehaviour
{
    public int scoreValue;

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController_updated controller = other.GetComponent<PlayerController_updated>();

        if (controller != null)
        {
            controller.AddScore(scoreValue);
            Destroy(gameObject);
        }
    }
}
