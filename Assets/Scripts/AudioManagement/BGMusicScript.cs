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
        if (GameObject.FindGameObjectsWithTag("MusicManager").Length > 1)
        {
            Destroy(GameObject.FindGameObjectsWithTag("MusicManager")[0]);
        }
        self = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        audioClips = new BGTrack[transform.childCount];
        for(int i = 0; i < audioClips.Length; i++)
        {
            Debug.Log(i);
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
            if(audioManager.volume < 0)
            {
                audioManager.clip = targetSong.music;
                audioManager.Play();
                audioManager.time = targetSong.musicPosition;
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
