using System.Collections;
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
    private int time;
    private CameraController cam;

    private void Start()
    {
        time = 0;
        score = 0;
        Player.OnDeath += ResetPlayer;
        FinishManager.GoalTouched += ResetPlayerAddScore;
        FinishManager.LevelFinish += LevelFinish;
        cam = CameraController.Get();
    }

    public void AddScore(int addScore)
    {
        score = addScore;
    }
    public void ResetPlayer(Player p)
    {        
        p.ResetPosition();
        cam.ResetPosition();
    }
    public void ResetPlayerAddScore(FinishManager f)
    {        
        Player.Get().ResetPosition();
        cam.ResetPosition();
        AddScore(500);
    }
    public void LevelFinish(FinishManager f)
    {
        AddScore(1000 - time);
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
}
