using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource[] audioSource;   // 所有(跳舞)音樂
    // public AudioSource[] BackgroundMusic;   // 非跳舞音樂
    public AudioClip[] audioClips;  // 所有音效

    AudioSource currentAudioSource; // 當前播放的音樂 => 當前選中的音樂

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAudio(int index)
    {
        if (currentAudioSource != null)
        {
            currentAudioSource.Stop();
        }

        currentAudioSource = audioSource[index];
        currentAudioSource.Play();
    }

    public void changeMusic()
    {
    }
}
