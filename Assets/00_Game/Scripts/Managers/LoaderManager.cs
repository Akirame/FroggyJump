using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoaderManager : MonoBehaviour
{

    #region singleton
    private static LoaderManager instance;
    public static LoaderManager Get()
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

    public float loadingProgress;
    public float timeLoading;
    public float minTimeToLoad = 2;

    private Scene currentScene;

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene("LoadingScreen");
        StartCoroutine(AsynchronousLoad(sceneName));
    }
    public bool OnLevel()
    {
        currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "Level1" || currentScene.name == "Level2" || currentScene.name == "Level3")
        {
            return true;
        }
        else
            return false;
    }
    IEnumerator AsynchronousLoad(string scene)
    {
        loadingProgress = 0;
        timeLoading = 0;
        yield return null;
        AsyncOperation ao = SceneManager.LoadSceneAsync(scene);
        ao.allowSceneActivation = false;        
        while (!ao.isDone)
        {
            timeLoading += Time.deltaTime;
            loadingProgress = ao.progress + 0.1f;
            loadingProgress = loadingProgress * timeLoading / minTimeToLoad;

            // Loading completed
            if (loadingProgress >= 1)
            {
                ao.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}