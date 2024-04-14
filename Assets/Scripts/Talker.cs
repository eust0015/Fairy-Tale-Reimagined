using System;
using System.Collections;
using System.Collections.Generic;
using RedBlueGames.Tools.TextTyper;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class Talker : MonoBehaviour
{
    [SerializeField] private TextTyper.TextTyper textTyper;
    [SerializeField] private TextMeshProUGUI textBox;
    
    private void OnEnable()
    {
        textTyper.TypeText(textBox.text);
    }
}
