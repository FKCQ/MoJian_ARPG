using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loading : MonoBehaviour {
    private UISlider progressBar;

    private void OnEnable()
    {
        progressBar = transform.Find("Progress").GetComponent<UISlider>();
        progressBar.value = 0;
        StartCoroutine(Load());
    }

    IEnumerator Load()
    {
        while(progressBar.value != 1)
        {
            progressBar.value += Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject);
    }
}
