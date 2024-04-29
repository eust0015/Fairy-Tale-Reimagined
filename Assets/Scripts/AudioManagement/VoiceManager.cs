using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] voiceLines;
    [SerializeField] private AudioSource player;
    public void PlayVoiceLine(string vlName)
    {
        for(int i = 0; i < voiceLines.Length; i++)
        {
            player.clip = voiceLines[i];
            if(player.clip.name == vlName)
            {
                return;
            }
        }
    }
}
