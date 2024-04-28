using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    public string sfxName;
    public AudioClip sfx;
    [Range(0, 1)][SerializeField] public float sfxVolume;
    private AudioSource self;

    private void Start()
    {
        self = GetComponent<AudioSource>();
    }
    void Update()
    {
        if(!self.isPlaying)
        {
            gameObject.SetActive(false);
        }
    }
}
