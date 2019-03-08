using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour {
    private Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.K))
            CommontAtk();
	}

    /// <summary>
    /// 普通攻击
    /// </summary>
    public void CommontAtk()
    {
        //当前状态为第三、四次普攻，阻止输入————避免攻击延迟
        if (anim.GetCurrentAnimatorClipInfo(0)[0].clip.name == "zhankuang_pugong_03" || anim.GetCurrentAnimatorClipInfo(0)[0].clip.name == "zhankuang_pugong_04")
            return;
        anim.SetTrigger("CommonAtk");
    }


}
