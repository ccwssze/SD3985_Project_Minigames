using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Leaderboard : MonoBehaviour
{
    [Header("Options")]
    public float refreshRate = 1f;

    [Header("UI")]
    public GameObject[] slots;

    [Space]
    public Text[] scoreTexts;
    public Text[] nameTexts;

    public GameObject showWinner;
    public static string winnerName;
    public Text winnerNameText;

    public float waitTime = 5f;

    void Start()
    {
        InvokeRepeating(nameof(Refresh), 1f, refreshRate);
    }

    public void Refresh()
    {
        foreach (var slot in slots)
        {
            slot.SetActive(false);
        }

        var sortPlayerList = (from player in PhotonNetwork.PlayerList orderby player.GetScore() descending select player).ToList();

        int i = 0;
        foreach (var player in sortPlayerList)
        {
            slots[i].SetActive(true);

            if (player.NickName == "")
                player.NickName = "unnamed";

            nameTexts[i].text = player.NickName;
            scoreTexts[i].text = player.GetScore().ToString();

            i++;
        }

        if (Timer.timerIsRunning == false)
        {
            showWinner.SetActive(true);
            winnerName = nameTexts[0].text;
            winnerNameText.text = winnerName;

            StartCoroutine(changeScene("Lobby"));
        }
    }
    IEnumerator changeScene(string scene)
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(scene);
    }
}
