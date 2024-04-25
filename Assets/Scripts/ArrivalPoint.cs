using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrivalPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            JumpingPlayerController.endGame = true;
        }
    }
}
