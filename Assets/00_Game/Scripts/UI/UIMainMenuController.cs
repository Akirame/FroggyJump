using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMainMenuController : MonoBehaviour {

    public GameObject imageStart;
    public GameObject imageExit;

    private Animator anim;
    private bool onStart;
    private bool selected;

    private void Start()
    {
        anim = GetComponent<Animator>();
        imageStart.SetActive(true);
        imageExit.SetActive(false);
        onStart = true;
        selected = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && onStart)
        {            
            imageStart.SetActive(false);
            imageExit.SetActive(true);
            onStart = false;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && !onStart)
        {                     
            imageStart.SetActive(true);
            imageExit.SetActive(false);
            onStart = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if (onStart && !selected)
            {
                anim.SetBool("Select", true);
                StartCoroutine(ChangeScene("Level1"));
                selected = true;
            }
            else
            {
                Application.Quit();
            }
        }
    }
        IEnumerator ChangeScene(string sceneName)
        {            
            yield return new WaitForSeconds(2);
            LoaderManager.Get().LoadScene(sceneName);
        }
}
