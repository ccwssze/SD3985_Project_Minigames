using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public float scoreValue = 10;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            JumpingPlayerController_updated player = other.GetComponent<JumpingPlayerController_updated>();
            player.AddScore(5);
        }
    }
}
