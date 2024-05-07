using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinManager : MonoBehaviour
{
    [SerializeField] LightBulb[] lights;
    AudioManager audioManager;
    //var for not calling CheckWinning every frame
    [SerializeField]private bool winned = false;
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
            GameObject.Find("Next").GetComponent<Button>().interactable = true;
            GameObject.Find("Next").GetComponentInChildren<TextMeshProUGUI>().alpha = 255;
            winned = true;
        }
        else if(!IsAllTrue(lights))
        {
            winned = false;
            GameObject.Find("Next").GetComponent<Button>().interactable = false;
            
            GameObject.Find("Next").GetComponentInChildren<TextMeshProUGUI>().alpha = 0; 
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
    public void NextButton()
    {
        if (SceneManager.GetActiveScene().buildIndex + 1 < 12)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else
            SceneManager.LoadScene(0);
    }
}
