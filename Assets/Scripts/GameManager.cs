using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] CanvasGroup fadeCanvasGroup;
    [SerializeField] float fadeSpeed = 2f;

    bool fadingIn = false;
    bool fadingOut = false;
    string sceneToLoad;

    void Start()
    {
        if (fadeCanvasGroup != null)
        {
            fadeCanvasGroup.alpha = 1f;
            fadingIn = true;
        }

    }

    void Update()
    {

        if (fadingOut && fadeCanvasGroup != null)
        {
            fadeCanvasGroup.alpha += Time.deltaTime * fadeSpeed;

            if (fadeCanvasGroup.alpha >= 1f)
            {
                SceneManager.LoadScene(sceneToLoad);
            }
        }

        if (fadingIn && fadeCanvasGroup != null)
        {
            fadeCanvasGroup.alpha -= Time.deltaTime * fadeSpeed;

            if (fadeCanvasGroup.alpha <= 0f)
            {
                fadeCanvasGroup.alpha = 0f;
                fadingIn = false;
            }
        }
    }

    public void LoadSceneByButton(string buttonName)
    {
        switch (buttonName)
        {
            case "Play":
                sceneToLoad = "Level 1";
                break;

            case "HowToPlay":
                sceneToLoad = "How to Play";
                break;

            case "Quit":
                Application.Quit();
                return;

            case "MainMenu":
                sceneToLoad = "MainMenu";
                break;

            default:
                Debug.Log("Button Not Found");
                break;
        }

        fadingOut = true;
    }
}
