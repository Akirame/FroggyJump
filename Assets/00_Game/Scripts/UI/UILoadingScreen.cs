using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UILoadingScreen : MonoBehaviour
{
    public Text loadingText;
    public Text levelNameText;

  
    private void Start()
    {
        switch (LoaderManager.Get().GetNextScene())
        {
            case "Level1":
                levelNameText.text = "Level 1";
                break;
            case "Level2":
                levelNameText.text = "Level 2";
                break;
            case "Level3":
                levelNameText.text = "Level 3";
                break;
            default:
                levelNameText.text = "";
                break;
        }
    }
    public void Update()
    {
        int loadingVal = (int)(LoaderManager.Get().loadingProgress * 100);
        loadingText.text = "Loading " + loadingVal;
        if (LoaderManager.Get().loadingProgress >= 1)
            Destroy(this.gameObject);
        
    }
    public void SetVisible(bool show)
    {
        gameObject.SetActive(show);
    }
}