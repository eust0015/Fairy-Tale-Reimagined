using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager SharedInstance;
    [SerializeField] SFXManagement sfxManager;
    [SerializeField] BGMusicScript musicManager;
    private void Awake()
    {
        SharedInstance = this;

        if (GameObject.FindGameObjectsWithTag("MusicManager").Length > 1)
        {
            Destroy(GameObject.FindGameObjectsWithTag("MusicManager")[0]);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void PlayMusic(string name)
    {
        musicManager.FadeTo(name);
    }
    public void PlaySoundEffect(string name)
    {
        sfxManager.PlaySFX(name);
    }

}
