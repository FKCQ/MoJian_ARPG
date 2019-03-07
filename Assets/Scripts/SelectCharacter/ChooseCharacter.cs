using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseCharacter : MonoBehaviour {
    public UILabel characteristic;          //英雄特性
    public UILabel introduce;               //英雄介绍

    public GameObject hero1;                //英雄模型1号
    public GameObject hero2;                //英雄模型2号
    public string head1Name;                //英雄1号的头像
    public string head2Name;                //英雄2号的头像
    public string hero1Introduce;           //英雄1号介绍信息
    public string hero2Introduce;           //英雄2号介绍信息
    public string hero1characteristic;      //英雄1号特性
    public string hero2characteristic;      //英雄2号特性

    private UILabel heroName;              //角色名称
    private UISprite head;                  //已选择的头像
    private UIToggle character1;            //英雄1号选择状态
    private UIToggle character2;            //英雄2号选择状态
    private string hero1Name;               //英雄1号名称
    private string hero2Name;               //英雄2号名称

    void Start () {
        character1 = transform.Find("Container/0").GetComponent<UIToggle>();
        character2 = transform.Find("Container/1").GetComponent<UIToggle>();
        head = transform.Find("Selected/Back/Head").GetComponent<UISprite>();
        heroName = transform.Find("Selected/Label").GetComponent<UILabel>();
        hero1Name = "刺客";
        hero2Name = "狂战士";
    }

    public void OnSelectChange()
    {
        if (character1.value)//1号英雄已选择
        {
            //显示对应英雄模型
            hero1.SetActive(true);
            hero2.SetActive(false);

            //已选择头像显示
            head.spriteName = head1Name;

            //英雄特性
            characteristic.text = hero1characteristic;

            //英雄介绍
            introduce.text = hero1Introduce;

            //英雄名称
            heroName.text = hero1Name;
        }else if (character2.value)//2号英雄已选择
        {
            //显示对应英雄模型
            hero2.SetActive(true);
            hero1.SetActive(false);

            //已选择头像显示
            head.spriteName = head2Name;

            //英雄特性
            characteristic.text = hero2characteristic;

            //英雄介绍
            introduce.text = hero2Introduce;

            //英雄名称
            heroName.text = hero2Name;
        }
    }
}
