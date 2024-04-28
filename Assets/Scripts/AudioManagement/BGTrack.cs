using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGTrack : MonoBehaviour
{
    public string musicName;
    public AudioClip music;
    [Range(0, 1)][SerializeField] public float musicVolume;
    public float musicPosition = 0;
}
