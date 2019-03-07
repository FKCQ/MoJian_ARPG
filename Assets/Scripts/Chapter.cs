using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter : MonoBehaviour {
    private GameObject lockSprite;

    public GameObject LockSprite {
        get {
            if(lockSprite == null)
                lockSprite = transform.Find("Lock").gameObject;
            return lockSprite;
        }

        set {
            if (lockSprite.activeSelf)
                GetComponentInParent<UIButton>().enabled = false;
            else
                GetComponentInParent<UIButton>().enabled = true;
            lockSprite = value;
        }
    }


    private void OnEnable()
    {
        if (LockSprite.activeSelf)
            GetComponentInParent<UIButton>().enabled = false;
        else
            GetComponentInParent<UIButton>().enabled = true;
    }
    // Use this for initialization
    void Start () {
	}
	
}
