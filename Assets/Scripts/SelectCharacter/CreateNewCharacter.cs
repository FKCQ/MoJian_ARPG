using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewCharacter : MonoBehaviour {
    public void OnCreateNewCharacter(GameObject go,GameObject backButton,GameObject startButton)
    {
        gameObject.SetActive(false);
        backButton.SetActive(true);
        startButton.SetActive(true);
        go.SetActive(true);
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
