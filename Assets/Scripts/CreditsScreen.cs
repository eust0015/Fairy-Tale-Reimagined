using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsScreen : MonoBehaviour
{
    [SerializeField] private GameObject background;

    private void Start()
    {
        CreditsButton.OnClick += Show;
    }
    
    private void OnDestroy()
    {
        CreditsButton.OnClick -= Show;
    }
    
    private void Show()
    {
        background.SetActive(true);
    }
}
