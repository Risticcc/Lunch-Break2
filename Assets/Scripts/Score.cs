using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Score", menuName = "Lunch Break2/Score", order = 0)]
public class Score : ScriptableObject 
{
    public int score;

    [System.NonSerialized]
    public UnityEvent<int> scoreChanged;

    private  void OnEnable() {
        score = SaveLoad.Load(score.ToString());
        if(scoreChanged == null)
            scoreChanged = new UnityEvent<int>();
    }
    public void MoneyIncome(int amount)
    {
        score += amount;
        scoreChanged?.Invoke(score);
    }

    private void MoneyOutcome(int amount)
    {
        score -= amount;
        scoreChanged?.Invoke(score);
    }

    public bool PriceCheck(int amount)
    {
        if(amount >score)
            return false;
        else
        {
            MoneyOutcome(amount);
            return true;
        }
       
        
    }
}
