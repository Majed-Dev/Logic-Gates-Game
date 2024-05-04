using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.Find("Audio Manager").GetComponent<AudioManager>();
    }
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        audioManager.PlaySFX(audioManager.gate);
    }
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
        audioManager.PlaySFX(audioManager.gate);
    }
    public void Quit()
    {
        Application.Quit();
        print("Quit");
        audioManager.PlaySFX(audioManager.blockedGate);
    }
}
