using System;
using System.Collections;
using System.Collections.Generic;
using RedBlueGames.Tools.TextTyper;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class DialogueConfiguration : MonoBehaviour
{
    [SerializeField] private TextTyper.TextTyper textTyper;
    [SerializeField] private Button textButton;

    private void Start()
    {
        Configuration.OnTextPrintSpeedChanged += UpdatePrintDelaySetting;
        Configuration.OnTextBoxOpacityChanged += UpdateBackgroundOpacity;
    }
    
    private void OnDestroy()
    {
        Configuration.OnTextPrintSpeedChanged -= UpdatePrintDelaySetting;
        Configuration.OnTextBoxOpacityChanged -= UpdateBackgroundOpacity;
    }

    private void UpdatePrintDelaySetting(float sliderValue) => textTyper.printDelaySetting = sliderValue;

    private void UpdateBackgroundOpacity(float sliderValue)
    {
        ColorBlock colors = textButton.colors;
        colors.normalColor = new Color(0, 0, 0, sliderValue);
        colors.pressedColor = colors.normalColor;
        colors.highlightedColor = new Color(0, 0, 0, sliderValue + 0.02f);
        colors.selectedColor = colors.highlightedColor;
        
        textButton.colors = colors;
    }
}
