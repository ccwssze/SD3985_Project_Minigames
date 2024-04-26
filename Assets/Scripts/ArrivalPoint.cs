using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ArrivalPoint : MonoBehaviour 
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            JumpingPlayerController_updated player = other.GetComponent<JumpingPlayerController_updated>();
            player.AddScore(5);
            JumpingPlayerController_updated.endGame = true;
        }
    }
}
