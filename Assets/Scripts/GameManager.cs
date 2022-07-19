using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private GameObject _startPanel;
    private GameObject _gameOverPanel;
    private GameObject _levelUpPanel;

    private bool firstLoad = true;
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        _startPanel = GameObject.FindGameObjectWithTag("StartPanel");
        _levelUpPanel = GameObject.FindGameObjectWithTag("LevelUp");
        _gameOverPanel = GameObject.FindGameObjectWithTag("GameOverPanel");
        InitalizeGame();
    }

    private void InitalizeGame()
    {
        Time.timeScale = 0;
        _gameOverPanel.SetActive(false);

        if (!firstLoad)
            _levelUpPanel.SetActive(true);
        else
        {
            firstLoad = true;
            _levelUpPanel.SetActive(false);
            _startPanel.SetActive(true);
        }
    }

   
    

    public void Play()
    {
        _startPanel.SetActive(false);
        _gameOverPanel.SetActive(false);
        _levelUpPanel.SetActive(false);

        Time.timeScale = 1;
    }


    public void GameOver()
    {
        _gameOverPanel.SetActive(true);
        _startPanel.SetActive(false);
        _levelUpPanel.SetActive(false);

        Time.timeScale = 0;

    }


    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LevelUp()
    {
        //LevelManager.Instance.ChangeLevel();
        Time.timeScale = 0;
        _levelUpPanel.SetActive(true);
        //sound
        //conmfeti
    }

    //delete all data
    public void ResetGame()
    {
        SaveLoad.ResetGame();
        Play();
    }


}
