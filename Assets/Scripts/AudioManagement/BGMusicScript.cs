using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusicScript : MonoBehaviour
{
    public static BGMusicScript self;
    [Range(0, 5)][SerializeField] private float fadeSpeed;
    [SerializeField] AudioSource audioManager;
    [SerializeField] BGTrack[] audioClips;
    private BGTrack targetSong;
    private void Awake()
    {
        self = this;
    }
    void Start()
    {
        audioClips = new BGTrack[transform.childCount];
        for(int i = 0; i < audioClips.Length; i++)
        {
            audioClips[i] = transform.GetChild(i).GetComponent<BGTrack>();
        }
        FadeTo("MenuMusic");
    }
    void Update()
    {
        if(audioManager.clip != targetSong.music || audioManager.volume != targetSong.musicVolume)
        {
            Fade();
        }
    }
    public void FadeTo(string newTrack)
    {
        for (int i = 0; i < audioClips.Length; i++)
        {
            if (audioClips[i].musicName == newTrack)
            {
                targetSong = audioClips[i];
            }
        }
    }

    private void Fade()
    {
        if(audioManager.clip != targetSong.music)
        {
            if(audioManager.volume <= 0)
            {
                audioManager.clip = targetSong.music;
                audioManager.time = targetSong.musicPosition;
                audioManager.Play(); 
            }
            else
            {
                audioManager.volume -= Time.deltaTime;
            }
        }
        else if(audioManager.volume != targetSong.musicVolume)
        {
            audioManager.volume += Time.deltaTime;
            if(audioManager.volume > targetSong.musicVolume)
            {
                audioManager.volume = targetSong.musicVolume;
            }
        }
    }
}
