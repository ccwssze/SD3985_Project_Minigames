using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class CameraFollow : MonoBehaviour
{
    public float CameraSpeed;
    PhotonView view;
    public GameObject player;


    void Start()
    {
        view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        player = GameObject.FindWithTag("Player");
        if (player != null) 
        {
            transform.position =  new Vector3(player.transform.position.x, 0f, -10f);
        }
    }
}
