using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections.Generic;

public class Settings : MonoBehaviour
{
    public AudioMixer am;
    public Slider slider;
    public Dropdown drop;
    Resolution[] rsl;
    List<string> resolutions;
    public Dropdown dropdown;
    bool isFullScreen = false;
    public void Awake()
    {
        resolutions = new List<string>();
        rsl = Screen.resolutions;
        foreach (var i in rsl)
        {
            resolutions.Add(i.width + "x" + i.height);
        }
        dropdown.ClearOptions();
        dropdown.AddOptions(resolutions);
        slider.value = -70f;
        am.SetFloat("MasterVolume", slider.value);
        Debug.Log(Screen.currentResolution.width + "x" + Screen.currentResolution.height);
       // dropdown. = Screen.currentResolution.width + "x" + Screen.currentResolution.height;
    }
    public void Resolution()
    {
        Screen.SetResolution(rsl[dropdown.value].width, rsl[dropdown.value].height, isFullScreen);
    }
    public void FullScreenToggle()
    {
        isFullScreen = !isFullScreen;
        Screen.fullScreen = isFullScreen;
    }
    public void AudioVolume()
    {
        am.SetFloat("MasterVolume", slider.value);
    }
    public void Quality()
    {
        QualitySettings.SetQualityLevel(drop.value);
    }
}
