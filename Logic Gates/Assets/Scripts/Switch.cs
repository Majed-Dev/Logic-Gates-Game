using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] private bool on = false;
    [SerializeField] private bool isSwitchable = true;
    [SerializeField] private Line line;
    SpriteRenderer spriteRenderer;
    [SerializeField] Sprite onSprite, offSprite;
    AudioManager audioManager;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioManager = GameObject.Find("Audio Manager").GetComponent<AudioManager>();
    }
    private void Update()
    {
        line.setIsActive(on);
        if(on)
          spriteRenderer.sprite = onSprite;
        else
            spriteRenderer.sprite = offSprite;

        if (!isSwitchable && !on)
            spriteRenderer.color = Color.red;
        else if(!isSwitchable && on)
            spriteRenderer.color = Color.green;
    }

    private void OnMouseDown()
    {
        if (!isSwitchable)
        {
            audioManager.PlaySFX(audioManager.notSwitchable);
            return;
        }
        
        audioManager.PlaySFX(audioManager.switchClick);
        if (on)
        {
            on = false;
        }
        else if (!on)
        {
            on = true;
        }
    }
}
