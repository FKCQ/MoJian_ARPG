using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonModal : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //先打开UIpanel，再打开目标面板
    public void OpenPanel(GameObject panel, GameObject targetPanel)
    {
        if (targetPanel.activeSelf)
            return;
        UIPanel[] childPanel = panel.GetComponentsInChildren<UIPanel>();
        foreach (UIPanel uiPanel in childPanel)
        {
            if (uiPanel.gameObject.name == "Scroll View")
                continue;
            uiPanel.gameObject.SetActive(false);
        }

        panel.SetActive(true);
        targetPanel.SetActive(true);
    }
}
