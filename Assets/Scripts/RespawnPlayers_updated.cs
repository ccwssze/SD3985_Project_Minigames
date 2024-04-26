using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RespawnPlayers_updated : MonoBehaviour
{
    public GameObject respawnPoint;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            JumpingPlayerController_updated player = other.GetComponent<JumpingPlayerController_updated>();
            if (player != null)
            {
                other.transform.position = respawnPoint.transform.position;
                player.SetScore(0);
            }
        }
    }
}
