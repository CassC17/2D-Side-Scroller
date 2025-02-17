using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadSceneAfterDelay(string sceneName, float delay)
    {
        StartCoroutine(WaitAndLoad(sceneName, delay));
    }

    // Surcharge for buttons
    public void LoadScene(string sceneName)
    {
        LoadSceneAfterDelay(sceneName, 1f);
    }

    private IEnumerator WaitAndLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
