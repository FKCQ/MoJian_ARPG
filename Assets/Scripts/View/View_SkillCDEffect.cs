using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View_SkillCDEffect : MonoBehaviour {
    public float cdTimer = 2f;
    private UIButton skillButton;
    private UISprite cdImage;

    private void OnEnable()
    {
        cdImage = GetComponent<UISprite>();
        skillButton = GetComponentInParent<UIButton>();
        cdImage.enabled = false;

    }

    public void UseSkill()
    {
        cdImage.enabled = true;
        cdImage.fillAmount = 1;
        skillButton.enabled = false;
        StartCoroutine(Effect());
    }

    IEnumerator Effect()
    {
        while(cdImage.fillAmount != 0)
        {
            cdImage.fillAmount -= Time.deltaTime / cdTimer;
            yield return null;
        }
        skillButton.enabled = true;
        cdImage.enabled = false;
        StopCoroutine(Effect());
    }
}
