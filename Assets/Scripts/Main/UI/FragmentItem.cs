using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentItem : MonoBehaviour {
    public int amount = 10;         //需要集齐的总量
    public UIButton buttonToggle;
    private UISlider slider;
    private UILabel sliderLabel;
    private int count;              //拥有的数量

    private void Start()
    {
        buttonToggle = GetComponent<UIButton>();
        buttonToggle.enabled = false;
        Count = 0;
    }

    public int Count {
        get {
            return count;
        }

        set {
            count = value;
            //碎片集齐，使按钮能够点击
            if (count >= amount)
                buttonToggle.enabled = true;
            else
                buttonToggle.enabled = false;

            Slider.value = count / (float)amount;
            SliderLabel.text = "[b]" + count + "/" + amount + "[-]";
        }
    }

    public UILabel SliderLabel {
        get {
            if(sliderLabel == null)
                sliderLabel = transform.Find("Slider/Label").GetComponent<UILabel>();

            return sliderLabel;
        }

        set {
            sliderLabel = value;
        }
    }

    public UISlider Slider {
        get {
            if (slider == null)
                slider = GetComponentInChildren<UISlider>();
            return slider;
        }

        set {
            slider = value;
        }
    }

    public void GetEquipment()
    {
        Count -= amount;
        Debug.Log("获得新装备");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            Count++;
    }
}
