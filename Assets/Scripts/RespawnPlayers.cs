using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RespawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject respawnPoint;

    private void Start()
    {
        PhotonNetwork.Instantiate(playerPrefab.name, respawnPoint.transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.transform.position = respawnPoint.transform.position;
        }
    }
}
