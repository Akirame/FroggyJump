using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public delegate void UIactions(UIManager u);
    public UIactions ResetGame;

    public GameObject gameCanvas;
    public Text scoreGame;
    public Text timeGame;
    public Image livesGame;
    private int score;

    public GameObject pauseCanvas;

    public GameObject levelFinishCanvas;


    private void Start()
    {
        gameCanvas.SetActive(true);
        pauseCanvas.SetActive(true);
        levelFinishCanvas.SetActive(true);
    }

    private void Update()
    {
        
    }
    private void DrawTime()
    {
        timeGame.text = Mathf.FloorToInt(GameManager.Get().GetTime()).ToString("000");
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
        ResetGame(this);
    }
}
