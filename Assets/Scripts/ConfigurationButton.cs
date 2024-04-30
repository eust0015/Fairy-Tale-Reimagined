using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigurationButton : MonoBehaviour
{
    public delegate void ClickEvent();
    public static event ClickEvent OnClick;
    
    public void Click()
    {
        OnClick?.Invoke();
    }
}
