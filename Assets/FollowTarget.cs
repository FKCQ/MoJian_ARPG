using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour {
    public float maxSpeed = 5f;

    private Vector3 offset;
    private Transform target;
    private Vector3 targetPre;          //目标前一桢的位置————判断玩家是否移动

    private void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        targetPre = target.position;

        offset = transform.position - target.position;
        
    }
    private void Update()
    {
        //判断目标位置是否变化，决定相机是否移动
        if(targetPre - target.position != Vector3.zero)
        {
            transform.position = target.position + offset; 
            targetPre = target.position;
        }

    }
}
