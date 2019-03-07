using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewCharacter : MonoBehaviour {
    public GameObject selectPanel;
    public void OnCreateNewCharacter(GameObject go)
    {
        selectPanel.SetActive(false);
        go.SetActive(true);
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
