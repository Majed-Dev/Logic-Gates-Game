using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    
    [SerializeField] private AudioSource musicAudioSource;
    [SerializeField] private AudioSource SFXAudioSource;
    [Header("------Music------")]
    [SerializeField] private AudioClip musicClip;
    [Header("------SFX-------")]
    public AudioClip gate;
    public AudioClip blockedGate;
    public AudioClip lightOn;
    public AudioClip switchClick;
    public AudioClip notSwitchable;


    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        musicAudioSource.clip = musicClip;
        musicAudioSource.Play();
    }
    
    public void PlaySFX(AudioClip clip)
    {
        SFXAudioSource.PlayOneShot(clip);

    }
    
}
