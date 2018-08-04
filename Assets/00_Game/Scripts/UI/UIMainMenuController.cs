using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMainMenuController : MonoBehaviour {

    public GameObject imageStart;
    public GameObject imageExit;
    public AudioClip audioMove;
    public AudioClip audioSelect;

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
            Debug.Log("holi");
            //AudioSource.PlayClipAtPoint(audioMove, CameraController.Get().transform.position, 0.70f);
            imageStart.SetActive(false);
            imageExit.SetActive(true);
            onStart = false;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && !onStart)
        {            
           // AudioSource.PlayClipAtPoint(audioMove, CameraController.Get().transform.position, 1f);
            imageStart.SetActive(true);
            imageExit.SetActive(false);
            onStart = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
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
            //AudioSource.PlayClipAtPoint(audioSelect, CameraController.Get().transform.position, 1f);
            yield return new WaitForSeconds(2);
            LoaderManager.Get().LoadScene(sceneName);
        }
}
