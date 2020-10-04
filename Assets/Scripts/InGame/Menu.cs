using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Menu : MonoBehaviour
{
    public GameObject panel;
    public AudioMixer mixerLowPass;
    public Slider sliderSound;
    public static float sliderValue = .5f;
bool onPause = false;
void Start(){
    sliderSound.value = sliderValue;
}
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !onPause){
            panel.SetActive(true);
            Time.timeScale = 0f;
            onPause = true;
        }else if (Input.GetKeyDown(KeyCode.Escape) && onPause){
            Resume();
        }
        sliderValue = sliderSound.value;
        SetVolume(sliderValue);
    }
    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
    public void GoMenu(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void Resume(){
        onPause = false;
        Time.timeScale = 1f;
        panel.SetActive(false);
    }
    public void Quit(){
        Time.timeScale = 1f;
        Application.Quit();
    }
    public void SetVolume(float sliderValue){
        mixerLowPass.SetFloat("Volume" ,Mathf.Log10(sliderValue)*20);
    }
}
