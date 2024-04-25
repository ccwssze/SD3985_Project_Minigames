using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RespawnPlayers_updated : MonoBehaviour
{
    public GameObject respawnPoint;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.transform.position = respawnPoint.transform.position;
        }
    }
}
