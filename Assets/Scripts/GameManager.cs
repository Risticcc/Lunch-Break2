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
    private Animator animator;
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

        animator = GetComponent<Animator>();
        //ScoreManager.Instance.LoadScore();
    }

    

    private void InitalizeGame()
    {
        Time.timeScale = 0;
        _gameOverPanel.SetActive(false);

        if(SceneManager.GetActiveScene().name == "frizider")
        {
            _levelUpPanel.SetActive(true);
            _startPanel.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
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
        EnergyBar.Instance.EmptyBar();
        Debug.Log("3");

       // animator.SetTrigger("start");
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



    //delete all data
    public void ResetGame()
    {
        SaveLoad.ResetGame();
        Play();
    }

    //back to work
    public void NextLevel()
    {
        _levelUpPanel.SetActive(false);
        Debug.Log("sledeci  level");

        string nextLevel = LevelManager.Instance.LevelLoader();
        SceneManager.LoadScene(nextLevel);
    }
}
