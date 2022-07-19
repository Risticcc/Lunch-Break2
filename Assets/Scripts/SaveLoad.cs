using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static  class SaveLoad 
{
    public static void Save(string key, int value)
    {
        PlayerPrefs.SetInt(key,value);
    }

    public static int Load(string key)
    {
        return PlayerPrefs.GetInt(key);
    }

    public static void ResetGame()
    {
        PlayerPrefs.DeleteAll();
    }
    //dodaj neko dugme u meniju

}
