using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    [SerializeField] float transitionTime = 1f;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        spriteRenderer.color -= new Color(0, 0, 0, 1)* transitionTime * Time.deltaTime;
    }
}
