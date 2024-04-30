using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigurationScreen : MonoBehaviour
{
    [SerializeField] private GameObject background;

    private void Start()
    {
        ConfigurationButton.OnClick += Show;
    }
    
    private void OnDestroy()
    {
        ConfigurationButton.OnClick -= Show;
    }
    
    private void Show()
    {
        background.SetActive(true);
    }
}
