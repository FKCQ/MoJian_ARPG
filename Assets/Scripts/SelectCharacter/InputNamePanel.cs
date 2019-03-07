using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputNamePanel : MonoBehaviour
{
    public UILabel tips;
    public int fadeTime = 3;
    public float timeToFade = 0.5f;
    private UILabel playerName;
    private const string hint = "Input your name...";

    // Use this for initialization
    void Start()
    {
        playerName = transform.Find("InputNameField/Label").GetComponent<UILabel>();
    }

    public void OnCancel()
    {
        playerName.text = hint; 
        gameObject.SetActive(false);
    }

    public void OnConfirm()
    {
        //如果用户未输入,则给出提示
        if(playerName.text != string.Empty && !playerName.text.Equals("Input your name..."))
        {
            //TODO:存储玩家名称
            Debug.Log(playerName.text);
            //TODO:页面跳转

            //隐藏输入面板
            gameObject.SetActive(false);
        }
        else
        {
            //显示“提示用户输入名称”的文本,使用褪色效果
            StopAllCoroutines();
            StartCoroutine(Fade());
        }
        
    }

    IEnumerator Fade()
    {
        Color resetColor = tips.color;
        resetColor.a = 1;
        tips.color = resetColor;

        yield return new WaitForSeconds(timeToFade);
        while(tips.color.a > 0)
        {
            Color newColor = tips.color;
            newColor.a -= Time.deltaTime / fadeTime;
            tips.color = newColor;

            yield return null;
        }
    }
}
