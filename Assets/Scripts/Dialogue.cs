using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private GameObject background;
    [SerializeField] private Dialogue nextDialogue;
    [SerializeField] private Dialogue[] dialogueOptions;

    private void OnEnable()
    {
         QuitButton.OnClick += Hide;
    }
    
    private void OnDisable()
    {
        QuitButton.OnClick -= Hide;
    }

    public void Display()
    {
        background.SetActive(true);
    }

    private void Hide()
    {
        background.SetActive(false);
    }
    
    public void NextDialogue()
    {
        if (nextDialogue == null) return;

        Hide();
        nextDialogue.Display();
    }
    
    public void DialogueOption(int index)
    {
        if (dialogueOptions.Length <= index) return;

        Hide();
        dialogueOptions[index].Display();
    }
}
