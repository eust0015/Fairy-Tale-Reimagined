
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
    private string text;
    
    private void OnEnable()
    {
        if (text == null) text = textBox.text;
        AudioManager.SharedInstance.PlaySoundEffect("Text"+(int)Random.Range(1,5));
        textTyper.TypeText(text);
    }
}
