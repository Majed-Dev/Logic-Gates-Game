using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] private bool isSwitchOn = false;
    [SerializeField] private bool isSwitchable = true;
    [SerializeField] private Line[] lines;
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
        foreach(Line line in lines)
        {
            line.setIsActive(isSwitchOn);
        }
        if(isSwitchOn)
          spriteRenderer.sprite = onSprite;
        else
            spriteRenderer.sprite = offSprite;

        if (!isSwitchable && !isSwitchOn)
            spriteRenderer.color = Color.red;
        else if(!isSwitchable && isSwitchOn)
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
        if (isSwitchOn)
        {
            isSwitchOn = false;
        }
        else if (!isSwitchOn)
        {
            isSwitchOn = true;
        }
    }
}
