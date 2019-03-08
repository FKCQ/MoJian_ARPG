using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float rotateSpeed = 5f;              //旋转速度
    public float speed = 5f;                    //移动速度

    private float animSpeed = 5f;               //移动动画切换速度
    private Rigidbody rigidbody;
    private Animator anim;
    // Use this for initialization
    void Start() {
        rigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Move(-h, -v);
    }
    
    void Move(float h, float v)
    {
        if(h != 0 || v != 0)
        {
            rigidbody.velocity = new Vector3(h * speed, 0, v * speed);
            animSpeed = rigidbody.velocity.magnitude / speed;
            anim.SetFloat("Speed", animSpeed);

            Rotate(h,v);
        }
    }

    void Rotate(float h, float v)
    {
        Vector3 direction = new Vector3(h, 0, v);
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.localRotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotateSpeed);
    }
}
