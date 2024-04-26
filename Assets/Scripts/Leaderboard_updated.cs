using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Leaderboard_updated : MonoBehaviour
{
    public int noOfPlayers = 4;
    public GameObject[] playerList;
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

    public string nextScene;

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
       
        var sortPlayerList = (from player in playerList orderby player.GetComponent<PlayerController_updated>().GetScore() descending select player).ToList();

        int i = 0;
        foreach (var player in sortPlayerList)
        {
            if (i >= noOfPlayers) break;

            var playerController = player.GetComponent<PlayerController_updated>();

            slots[i].SetActive(true);

            var nickname = player.name;

            nameTexts[i].text = nickname;
            scoreTexts[i].text = playerController.GetScore().ToString();

            i++;
        }

        GameObject[] playerObjects = GameObject.FindGameObjectsWithTag("Player");
        var sortPlayerObjects = playerObjects.OrderBy(player => player.name).ToList();

        for (int n = 0; n < playerObjects.Length; n++)
        {
            if (n < noOfPlayers)
            {
                sortPlayerObjects[n].SetActive(true);
            }
            else
            {
                sortPlayerObjects[n].SetActive(false);
            }
        }

        if (PlayerController_updated.endGame == true)
        {
            showWinner.SetActive(true);

            if (scoreTexts[0].text == scoreTexts[1].text)
            {
                winnerName = "";
            }
            else
            {
                winnerName = nameTexts[0].text;
            }

            winnerNameText.text = winnerName;
            StartCoroutine(changeScene(nextScene));
        }
    }
    IEnumerator changeScene(string scene)
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(scene);
    }

    public string GetWinner()
    {
        return winnerName;
    }
}
