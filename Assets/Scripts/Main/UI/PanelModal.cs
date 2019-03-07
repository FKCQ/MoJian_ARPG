using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelModal : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnCloseClick()
    {
        transform.gameObject.SetActive(false);
        transform.GetComponentInParent<UIPanel>().gameObject.SetActive(false);
    }
}
