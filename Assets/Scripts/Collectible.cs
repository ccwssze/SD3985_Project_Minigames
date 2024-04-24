using Cainos.PixelArtTopDown_Basic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using ExitGames.Client.Photon;
public class Collectible : MonoBehaviour
{
    public int scoreValue;

    void OnTriggerEnter2D(Collider2D other)
    {
        PhotonView view = other.GetComponent<PhotonView>();
        PlayerController controller = other.GetComponent<PlayerController>();

        if (controller != null)
        {
            if (view.IsMine)
            {
                PhotonNetwork.LocalPlayer.AddScore(scoreValue);
            }
            Destroy(gameObject);
        }
    }
}
