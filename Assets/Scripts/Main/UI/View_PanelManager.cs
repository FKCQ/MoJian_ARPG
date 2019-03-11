using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View_PanelManager: MonoBehaviour {
    public GameObject functionPanel;
    public GameObject functionPanelTop;
    public UIPanel[] allPanel;

    //打开FunctionPanel
    public void OpenFunctionPanel(GameObject targetPanel1, GameObject targetPanel2 = null)
    {
        if (targetPanel1.activeSelf)
            return;
        foreach (UIPanel uiPanel in allPanel)
        {
            uiPanel.gameObject.SetActive(false);
        }
        if(!functionPanel.activeSelf)
            functionPanel.SetActive(true);
        if(!functionPanelTop.activeSelf)
            functionPanelTop.SetActive(true);

        targetPanel1.SetActive(true);
        if(targetPanel2 != null)
        {
            targetPanel2.SetActive(true);
        }
    }
    //打开两个Panel
    public void OpenTwoPanel(GameObject Panel1,GameObject panel2)
    {
        Panel1.SetActive(true);
        panel2.SetActive(true);
    }
    //打开单个panel
    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
    }
    //关闭单个panel
    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }

    //关闭FunctionPanel
    public void CloseAllPanel()
    {
        for (int i = 0; i < allPanel.Length; i++)
        {
            allPanel[i].gameObject.SetActive(false);
        }

    }
}
