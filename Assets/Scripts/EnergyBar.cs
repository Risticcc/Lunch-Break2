using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnergyBar : MonoBehaviour
{
    public static EnergyBar Instance {get;private set;}
    public GameObject Bar { get => bar; set => bar = value; }

    [SerializeField] private GameObject bar;
    [SerializeField] int time;
    private static bool filling = false;

    // Start is called before the first frame update
    void Start()
    {
        if(Instance == null){
            Instance = this;
        }
        else
            Destroy(gameObject);

        if(!filling)
            EmptyBar();  
    }

   
    public void EmptyBar()
    {
        LTDescr lt = LeanTween.scaleX(Bar,0,time);

       
            lt.setOnComplete(LoadMarket);
       
    }

    public void Fill(float amount)
    {
        filling = true;
        LeanTween.scaleX(Bar,amount,1f);
        filling = false;
    }

    

    private void LoadMarket()
    {
         if(Bar.transform.localScale.x == 0 && ScoreManager.Instance.Score.score == 0)
        {
            GameManager.Instance.GameOver();
            Debug.Log("GO");
        }
        else
            GameManager.Instance.MarketTransition();
            //SceneManager.LoadScene("frizider");
    }
}
