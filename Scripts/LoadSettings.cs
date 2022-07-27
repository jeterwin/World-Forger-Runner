using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class LoadSettings : MonoBehaviour
{
    public Slider audioSlider;
    public AudioMixer audioMixer;
    private void Start()
    {
        if (PlayerPrefs.HasKey("volume"))
        {
            audioMixer.SetFloat("volume", Mathf.Log10(PlayerPrefs.GetFloat("volume")) * 20);
            audioSlider.value = PlayerPrefs.GetFloat("volume");
            Debug.Log(PlayerPrefs.GetFloat("volume", 0.25f));
        }
    }
    public void changeVolume()
    {
        float volume = audioSlider.value;
        audioMixer.SetFloat("volume", Mathf.Log10(volume) * 20);
            PlayerPrefs.SetFloat("volume", volume);
            PlayerPrefs.Save();
    }
}
