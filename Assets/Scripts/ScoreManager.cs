using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static  ScoreManager Instance {get; private set;}
    public Score Score { get => score; set => score = value; }
    float fill = 0;

    //private static int _score = 0;
    [SerializeField] Score score;
    [SerializeField] private TMPro.TextMeshProUGUI _scoreUI;

    void Start()
    {
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(gameObject);

       // Score.score = SaveLoad.Load(score.ToString());
        //SaveLoad.ResetGame();
        Score.scoreChanged.AddListener(ScoreDisplay);
    }

    public void AddScore(int amount)
    {
        Score.MoneyIncome(amount);
    }

    public bool  MoneySpent(int amount, float boost)
    {
        if(!Score.PriceCheck(amount))
            return false;

        fill += boost;
        if(fill >= 3)
            fill = 3;
            
        EnergyBar.Instance.Fill(fill);
        return true;
    }


    public void ScoreDisplay(int amount)
    {
        _scoreUI.text = amount.ToString();     
        SaveLoad.Save("score",amount);
    }

   
}
