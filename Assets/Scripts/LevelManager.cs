using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance {get; private set;}
    private int currnetLevel=1;
    private int  levelNum;


    void Start()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        levelNum = SceneManager.sceneCountInBuildSettings;
    }


    public string LevelLoader()
    {
        int old = currnetLevel;

        if(currnetLevel == old)
            currnetLevel = Random.Range(1,levelNum);

        Debug.Log(currnetLevel);
        string levelName = "level" + currnetLevel;
        return levelName;
    }

    
}
