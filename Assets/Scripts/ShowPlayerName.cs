using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class ShowPlayerName : MonoBehaviourPunCallbacks
{
    void Start()
    {
        GetComponent<Text>().text = photonView.Owner.NickName;
    }
}
