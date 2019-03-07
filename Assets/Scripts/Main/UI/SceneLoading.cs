using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoading : MonoBehaviour {
    public GameObject loadingPanel;
	// Use this for initialization
	void Start () {
        Instantiate(loadingPanel);
	}
	
}
