using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static  ScoreManager Instance {get; private set;}
    
    private static int _score = 0;
    [SerializeField] private TMPro.TextMeshProUGUI _scoreUI;

    void Start()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        //Load();
        SaveLoad.ResetGame();
    }

    public void AddScore()
    {
        _score++;
        ScoreDisplay();
    }

    public void MoneySpent(int amount)
    {
        _score -= amount;
        ScoreDisplay();
    }


    public void ScoreDisplay()
    {
        _scoreUI.text = _score.ToString();     
        SaveLoad.Save("score",_score);
    }

   
}
