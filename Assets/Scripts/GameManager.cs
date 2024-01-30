using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour {

    public GameObject GameOverPanel;

    public TextMeshProUGUI currScoreText;

    int currScore;

	// Use this for initialization
	void Start () {

        currScore = 0;
        ScoreSetting();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GameOver()
    {
        Debug.Log("Game Over!");
        GameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void ScoreIncrement()
    {
        currScore++;
        ScoreSetting();

    }

    public void ScoreSetting()
    {
        currScoreText.text = currScore.ToString();
    }
}
