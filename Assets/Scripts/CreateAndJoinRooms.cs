using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public InputField createInput;
    public InputField joinInput;
    public InputField playerNickname;

    public void CreateRoom()
    {
        PhotonNetwork.NickName = playerNickname.text;
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.CreateRoom(createInput.text);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInput.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Minigame2");
    }

    public void PlayerName()
    {
        PhotonNetwork.NickName = playerNickname.text;
        PhotonNetwork.ConnectUsingSettings();
    }
}
