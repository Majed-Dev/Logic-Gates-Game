using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WinManager : MonoBehaviour
{
    [SerializeField] LightBulb[] lights;
    AudioManager audioManager;
    //var for not calling CheckWinning every frame
    bool winned = false;
    void Start()
    {
        audioManager = GameObject.Find("Audio Manager").GetComponent<AudioManager>();
    }

    void Update()
    {
        CheckWinning();
    }
    private void CheckWinning()
    {
        if(IsAllTrue(lights) && !winned)
        {
            print("Win");
            
            
            winned = true;
        }
    }
    private bool IsAllTrue(LightBulb[] lights)
    {
        for(int i=0; i<lights.Length; i++)
        {
            if (!lights[i].bulbOn)
            {
                return false;
            }
        }
        return true;
    }
}
