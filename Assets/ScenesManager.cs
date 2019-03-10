using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour {
    

    private AsyncOperation async = null;
    private float progressValue;
    private UISlider slider;
    private UILabel label;
    private void OnEnable()
    {
        slider = transform.Find("Progress").GetComponent<UISlider>();
        label = transform.Find("Progress/Label").GetComponent<UILabel>();
        slider.value = 0;
        LoadScene();
    }

    public void LoadScene()
    {
        StartCoroutine(Load());
    }

    IEnumerator Load()
    {
        async = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex+1);
        async.allowSceneActivation = false;
        while (!async.isDone)
        {
            if (async.progress < 0.9f)
                progressValue = async.progress;
            else
                progressValue = 1.0f;

            slider.value = progressValue;
            label.text = (int)(progressValue * 100f) + " %";

            if (async.progress >= 0.9f)
                async.allowSceneActivation = true;
            yield return null;
        }
        Destroy(gameObject);
    }
}
