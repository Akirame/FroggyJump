using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public delegate void UIactions(UIManager u);
    public static UIactions ResetGame;

    public GameObject gameCanvas;
    public Text scoreGame;
    public Text timeGame;
    public Sprite[] livesGame;
    public Image livesImage;
    private int score;
    private int lives;

    public GameObject pauseCanvas;

    public GameObject levelFinishCanvas;


    private void Start()
    {
        gameCanvas.SetActive(true);
        pauseCanvas.SetActive(false);
        levelFinishCanvas.SetActive(false);
        score = 0;
        lives = Player.Get().GetLives();
        livesImage.sprite = livesGame[lives];
        scoreGame.text = score.ToString("0000000");
    }

    private void Update()
    {
        DrawTime();
        DrawScore();
        DrawLives();
    }
    private void DrawTime()
    {
        timeGame.text = Mathf.FloorToInt(GameManager.Get().GetTime()).ToString("000");
    }
    private void DrawScore()
    {
        if (score < GameManager.Get().GetScore())
        {
            score = GameManager.Get().GetScore();
            scoreGame.text = score.ToString("0000000");
        }
    }
    private void DrawLives()
    {
        if (lives != Player.Get().GetLives())
        {
            lives = Player.Get().GetLives();
            livesImage.sprite = livesGame[lives];
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
}
