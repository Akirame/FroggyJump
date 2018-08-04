using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFinalScreen : MonoBehaviour
{
    public Text scoreText;

    private void Start()
    {
        //scoreText.text = "Score : " + GameManager.Get().GetScore();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        }
    }
}
