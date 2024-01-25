using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{   
     public GameObject GameOverPanel;
     public TextMeshProUGUI currScoreText;
    int currScore;


    // Start is called before the first frame update
    void Start()
    {
        currScore = 0;
        // ScoreSetting();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameOver()
    {
        GameOverPanel.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadSceneSelect()
    {
        SceneManager.LoadScene(1);
    }
    public void ScoreIncrement()
    {
        Debug.Log("SCORE Click!");
        currScore++;
    }
}
