using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;
public class SettingsMenu : MonoBehaviour
{
    public GameObject loadingCanvasUI;
    public GameObject mainMenuCanvasUI;
    public Slider progressSlider;
    bool played = false;
    private float currentValue, targetValue;
    public UnityEvent finishedLoadingEvent;
    public void StartGame()
    {
        StartCoroutine(LoadLevel());
    }
    public IEnumerator LoadLevel()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("SpatialRunner");
        loadingCanvasUI.SetActive(true);
        mainMenuCanvasUI.SetActive(false);
        asyncLoad.allowSceneActivation = false;
        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            targetValue = asyncLoad.progress / 0.9f;

            currentValue = Mathf.MoveTowards(currentValue, targetValue, 0.25f * Time.deltaTime);
            progressSlider.value = currentValue;
            if(progressSlider.value == 1 && currentValue == 1)
            {
                if(played == false)
                {
                    finishedLoadingEvent.Invoke();
                    played = true;
                }    

                if (Input.GetKeyDown(KeyCode.Space))
                asyncLoad.allowSceneActivation = true;
            }

            yield return null;
        }
    }
    public void CloseGame()
    {
        Application.Quit();
    }
}
