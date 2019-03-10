using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back : MonoBehaviour {
    private GameObject functionPanel;

    private void Start()
    {
        functionPanel = transform.GetComponentInParent<UIPanel>().gameObject;
    }

    public void OnBackClick()
    {
        functionPanel.SetActive(false);
    }

    public void BackToLast(GameObject current, GameObject last,GameObject startButton)
    {
        gameObject.SetActive(false);
        current.SetActive(false);
        startButton.SetActive(false);
        last.SetActive(true);

    }
}
