using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    private AudioSource _audioSource;

    void Awake()
    {
        Instance = this;
        _audioSource = GetComponent<AudioSource>();
    }

  
   public void PlaySoundFX(AudioClip clip,float volume)
    {
        if (!FindObjectOfType<GameManager>().gameOver)
        {
            _audioSource.PlayOneShot(clip, volume);
        }
        
    }
}
