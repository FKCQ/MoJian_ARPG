using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ctrl_LoadScene : MonoBehaviour {
    public GameObject loadingPanel;
	// Use this for initialization
	public void OnClick() {
        Instantiate(loadingPanel);
	}
	
}
