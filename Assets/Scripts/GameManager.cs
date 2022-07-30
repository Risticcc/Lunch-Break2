using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] Button backToWork;

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
        backToWork.gameObject.SetActive(false);
        InitalizeGame();

        animator = GetComponent<Animator>();
        //ScoreManager.Instance.LoadScore();
    }

    

    private void InitalizeGame()
    {
        Time.timeScale = 0;
        _gameOverPanel.SetActive(false);
        _levelUpPanel.SetActive(false);

        if(SceneManager.GetActiveScene().name == "frizider")
        {  
            _startPanel.SetActive(false);
            backToWork.gameObject.SetActive(true);
            Time.timeScale = 1;
        }
        else
        {
            _startPanel.SetActive(true);
        }
    }

   
    

    public void Play()
    {
        _startPanel.SetActive(false);
       _gameOverPanel.SetActive(false);
        _levelUpPanel.SetActive(false);
        backToWork.gameObject.SetActive(false);

        Time.timeScale = 1;
        EnergyBar.Instance.EmptyBar();
        TinySauce.OnGameStarted();
       

       // animator.SetTrigger("start");
    }


    public void GameOver()
    {
       _gameOverPanel.SetActive(true);
        _startPanel.SetActive(false);
       // _levelUpPanel.SetActive(false);
        TinySauce.OnGameFinished(ScoreManager.Instance.Score.score);
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
        //_levelUpPanel.SetActive(false);
       

        string nextLevel = LevelManager.Instance.LevelLoader();
        SceneManager.LoadScene(nextLevel);
    }

    public void MarketTransition()
    {
        _levelUpPanel.SetActive(true);
        _startPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void Market()
    {
        SceneManager.LoadScene("frizider");
    }
}
