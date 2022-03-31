using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MapSizeUI : MonoBehaviour
{
    public Slider xSlider;
    public Slider ySlider;
    public TextMeshProUGUI xText;
    public TextMeshProUGUI yText;
    public GameSettings settingcontrol;

    public void ValueSetX()
    {
        xText.text = "X: " + xSlider.value;
        settingcontrol.MapX = (int)xSlider.value;
    }
    public void ValueSetY()
    {
        yText.text = "Y: " + ySlider.value;
        settingcontrol.MapY = (int)ySlider.value;
    }

    private void Start()
    {
        xText.text = "X: " + xSlider.value;
        yText.text = "Y: " + ySlider.value;
        settingcontrol.MapX = (int)xSlider.value;
        settingcontrol.MapY = (int)ySlider.value;
    }
}
