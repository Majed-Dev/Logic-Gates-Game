using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    private Action OnClick;

    [SerializeField] bool gateSwitchable = true;

    [SerializeField] private Sprite[] sprites;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject lineIn1,lineIn2,lineOut;
    SpriteMask mask;

    private string[] gate = {"and", "or","nand","nor","xnor","xor"};
    [SerializeField] private string currentGate = "and";
    private int index = 0;

    AudioManager audioManager;



    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        mask = GetComponent<SpriteMask>();
        audioManager = GameObject.Find("Audio Manager").GetComponent<AudioManager>();
        currentGate = gate[0];
        if (!gateSwitchable)
            spriteRenderer.color = Color.yellow;
    }
    void Update()
    {
        //updating sprite mask when switching
        mask.sprite = GetComponent<SpriteRenderer>().sprite;
        SetLineOutState();
    }
    private void OnEnable()
    {
        OnClick += SwitchGate;
        OnClick += SwitchGateSprite;
    }
    private void OnDisable()
    {
        OnClick -= SwitchGate;
        OnClick -= SwitchGateSprite;
    }
    private bool Operation(GameObject line1,GameObject line2)
    {
        switch (index)
        {
            case 0: return line1.GetComponent<Line>().getIsActive() & line2.GetComponent<Line>().getIsActive();
            case 1: return line1.GetComponent<Line>().getIsActive() | line2.GetComponent<Line>().getIsActive();
            case 2: return !(line1.GetComponent<Line>().getIsActive() & line2.GetComponent<Line>().getIsActive());
            case 3: return !(line1.GetComponent<Line>().getIsActive() | line2.GetComponent<Line>().getIsActive());
            case 4: return !(line1.GetComponent<Line>().getIsActive() ^ line2.GetComponent<Line>().getIsActive());
            case 5: return line1.GetComponent<Line>().getIsActive() ^ line2.GetComponent<Line>().getIsActive();

            default: return false;
        }
    }
    private void SetLineOutState()
    {
        if (Operation(lineIn1,lineIn2)) 
        {
            lineOut.GetComponent<Line>().setIsActive(true);
        }
        else
        {
            lineOut.GetComponent<Line>().setIsActive(false);
        }
    }
    private void SwitchGate()
    {
        if (index == gate.Length - 1)
        {
            index = 0;
        }
        else
        {
            index++;
        }
    }
    private void SwitchGateSprite()
    {
        spriteRenderer.sprite = sprites[index];
    }

    private void OnMouseDown()
    {
        if (!gateSwitchable)
        {
            audioManager.PlaySFX(audioManager.blockedGate);
            return;
        }

        audioManager.PlaySFX(audioManager.gate);
        OnClick?.Invoke();
    }

}

