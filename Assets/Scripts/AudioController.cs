using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayClip(AudioClip clip)
    {
        if(audioSource.isPlaying) {
            audioSource.Stop();
        }
        audioSource.PlayOneShot(clip);
    }
}
