using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBulb : MonoBehaviour
{
    private bool on;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite onSprite, offSprite;
    [SerializeField] Line line;
    AudioManager audioManager;
    private bool winAudioPlayed;
    void Start()
    {
        audioManager = GameObject.Find("Audio Manager").GetComponent<AudioManager>(); 
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (line.getIsActive())
        {
            spriteRenderer.sprite = onSprite;
            spriteRenderer.color = Color.yellow;
            PlayWinSound();

        }
        else
        {
            winAudioPlayed = false;
            spriteRenderer.sprite = offSprite;
            spriteRenderer.color = Color.white;
        }
    }
    private void PlayWinSound()
    {
        if (!winAudioPlayed)
        {
            audioManager.PlaySFX(audioManager.lightOn);
            winAudioPlayed = true;
        }

    }

}
