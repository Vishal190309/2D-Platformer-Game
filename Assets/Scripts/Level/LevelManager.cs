using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public LevelStatus GetLevelStatus(string level)
    {
        LevelStatus status = (LevelStatus)PlayerPrefs.GetInt(level,0);
        return status;
    }

    public void SetLevelStatus(string level, LevelStatus status)
    {
        PlayerPrefs.SetInt(level, (int)status);

    }
}
