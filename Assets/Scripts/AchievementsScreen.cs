using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementsScreen : MonoBehaviour
{
    [SerializeField] private GameObject background;

    private void Start()
    {
        AchievementsButton.OnClick += Show;
    }
    
    private void OnDestroy()
    {
        AchievementsButton.OnClick -= Show;
    }
    
    private void Show()
    {
        background.SetActive(true);
    }
}
