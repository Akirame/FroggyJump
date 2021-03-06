﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {
    #region singleton
    private static GameManager instance;
    public static GameManager Get()
    {
        return instance;
    }
    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(this.gameObject);
    }
    #endregion

    private int score;
    private float time;    

    private void Start()
    {
        time = 0;
        score = 0;        

        Player.OnDeath += ResetPlayer;
        FinishManager.GoalTouched += ResetPlayerAddScore;        
        UIManager.ResetGame += ResetGame;
        LoaderManager.LoadComplete += ResetTime;
    }
    private void Update()
    {
        time += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Z))
            LevelFinish();
    }
    public void AddScore(int addScore)
    {
        score = addScore;
    }
    public void ResetPlayer(Player p)
    {        
        p.ResetPosition();
        CameraController.Get().ResetPosition();
    }
    public void ResetPlayerAddScore(FinishManager f)
    {        
        Player.Get().ResetPosition();
        CameraController.Get().ResetPosition();
        AddScore(500);
    }
    public void LevelFinish()
    {        
        Scene currScene = SceneManager.GetActiveScene();
        switch (currScene.name)
        {
            case "Level1":
                LoaderManager.Get().LoadScene("Level2");
                break;
            case "Level2":
                LoaderManager.Get().LoadScene("Level3");
                break;
            case "Level3":
                LoaderManager.Get().LoadScene("FinalScreen");
                break;
        }
    }
    public void ResetGame(UIManager u)
    {
        score = 0;
        time = 0;
        LoaderManager.Get().LoadScene("MainMenu");
    }
    public float GetTime()
    {
        return time;
    }
    public int GetScore()
    {
        return score;
    }
    public void ResetTime(LoaderManager l)
    {
        time = 0;
    }
}
