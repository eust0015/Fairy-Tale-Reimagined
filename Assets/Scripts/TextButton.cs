using System.Collections;
using System.Collections.Generic;
using RedBlueGames.Tools.TextTyper;
using UnityEngine;
using UnityEngine.Events;

public class TextButton : MonoBehaviour
{
    [SerializeField] private TextTyper textTyper;
    [SerializeField] private UnityEvent nextDialogue = new UnityEvent();
    
    public void OnClick()
    {
        if (textTyper.IsTyping)
        {
            textTyper.Skip();
        }
        else
        {
            nextDialogue?.Invoke();
        }
    }
}
