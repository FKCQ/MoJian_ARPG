using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPanel : MonoBehaviour {
    private GameObject hide;
    private GameObject show;
    private TweenPosition tweenPosition;
    private bool toggle;

    private void Start()
    {
        hide = transform.Find("Hide").gameObject;
        show = transform.Find("Show").gameObject;
        tweenPosition = GetComponent<TweenPosition>();
        //设置当前位置与目的地位置
        tweenPosition.from = new Vector3(transform.localPosition.x, 0, 0);
        tweenPosition.to = new Vector3(transform.localPosition.x - 399f, 0, 0);
    }

    public void OnButtonClick()
    {
        if(toggle == false)
        {
            tweenPosition.PlayForward();
        }else
        {
            tweenPosition.PlayReverse();
        }

        toggle = !toggle;
        ButtonIconChange();
    }

    void ButtonIconChange()
    {
        hide.SetActive(toggle);
        show.SetActive(!toggle);
    }
}
