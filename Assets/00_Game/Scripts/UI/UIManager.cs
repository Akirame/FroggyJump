using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region singleton
    private static UIManager instance;
    public static UIManager Get()
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

    public delegate void UIactions(UIManager u);
    public static UIactions ResetGame;

    public GameObject gameCanvas;
    public Text scoreGameText;
    public Text timeGameText;
    public Sprite[] livesArray;
    public Image livesGameImage;
    private int score;
    private int lives;

    public GameObject pauseCanvas;

    public GameObject levelResultCanvas;
    public Text scoreResultText;
    public Text timeResultText;
    public Image livesResultImage;
    public Button winButton;
    public Button loseButton;    

    private void Start()
    {
        gameCanvas.SetActive(true);
        pauseCanvas.SetActive(false);
        levelResultCanvas.SetActive(false);
        score = 0;
        lives = Player.Get().GetLives();
        livesGameImage.sprite = livesArray[lives];
        scoreGameText.text = score.ToString("0000000");
        FinishManager.LevelFinish += ActivateFinishCanvasWin;
        Player.NoMoreLives += ActivateFinishCanvasLose;
        LoaderManager.LoadComplete += LevelLoaded;
    }

    private void Update()
    {
        DrawTime();
        DrawScore();
        DrawLives();
    }
    private void DrawTime()
    {
        timeGameText.text = Mathf.FloorToInt(GameManager.Get().GetTime()).ToString("000");
    }
    private void DrawScore()
    {
        if (score < GameManager.Get().GetScore())
        {
            score = GameManager.Get().GetScore();
            scoreGameText.text = score.ToString("0000000");
        }
    }
    private void DrawLives()
    {
        if (lives != Player.Get().GetLives())
        {
            lives = Player.Get().GetLives();
            livesGameImage.sprite = livesArray[lives];
        }
    }
    public void ActivatePause()
    {
        Time.timeScale = 0;
        gameCanvas.SetActive(false);
        pauseCanvas.SetActive(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        gameCanvas.SetActive(true);
        pauseCanvas.SetActive(false);
    }
    public void ToMainMenu()
    {
        Time.timeScale = 1f;
        ResetGame(this);
    }
    public void LevelFinish(bool win)
    {
        GameManager.Get().AddScore(1000 - Mathf.FloorToInt(GameManager.Get().GetTime()) + (Player.Get().GetLives() * 500));
        
        gameCanvas.SetActive(false);
        pauseCanvas.SetActive(false);
        levelResultCanvas.SetActive(true);
        if (win)
        {
            winButton.gameObject.SetActive(true);
            loseButton.gameObject.SetActive(false);
        }
        else
        {
            winButton.gameObject.SetActive(false);
            loseButton.gameObject.SetActive(true);
        }
        scoreResultText.text = "Score: " + score.ToString("0000000");
        timeResultText.text = "Time: " + Mathf.FloorToInt(GameManager.Get().GetTime()).ToString("000");
        livesResultImage.sprite = livesArray[Player.Get().GetLives()];
    }
    public void ActivateFinishCanvasWin(FinishManager f)
    {
        LevelFinish(true);
    }
    public void ActivateFinishCanvasLose(Player p)
    {
        LevelFinish(false);
    }
    public void NextLevel()
    {
        GameManager.Get().LevelFinish();
    }
    public void LevelLoaded(LoaderManager l)
    {        
        if (l.IsNextALevel())
        {
            gameCanvas.SetActive(true);
            pauseCanvas.SetActive(false);
            levelResultCanvas.SetActive(false);
        }
        else
        {
            gameCanvas.SetActive(false);
            pauseCanvas.SetActive(false);
            levelResultCanvas.SetActive(false);
        }
    }
}
