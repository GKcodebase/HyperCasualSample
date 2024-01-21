using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{   
     public GameObject GameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        
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
        Debug.Log("Button Click!");
        SceneManager.LoadScene(0);
    }
        public void LoadSceneSelect()
    {
        SceneManager.LoadScene(1);
    }
}
