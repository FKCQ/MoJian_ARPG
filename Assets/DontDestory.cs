﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestory : MonoBehaviour {
    public void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
