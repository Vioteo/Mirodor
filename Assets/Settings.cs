using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections.Generic;

public class Settings : MonoBehaviour
{
    public AudioMixer am;
    public Toggle togl;
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
        resolutions.Add(Screen.width.ToString() + "x" + Screen.height.ToString());
        foreach (var i in rsl)
        {
            resolutions.Add(i.width + "x" + i.height+" "+i.refreshRate+"Ghz");
        }
        dropdown.ClearOptions();
        dropdown.AddOptions(resolutions);
        dropdown.itemText.text = Screen.currentResolution.width + "x" + Screen.currentResolution.height;
        slider.value = -40.0f;
        am.SetFloat("MasterVolume", slider.value);
        Debug.Log(Screen.width + "x" + Screen.height);
        drop.value = QualitySettings.GetQualityLevel();
        isFullScreen = Screen.fullScreen;
        togl.isOn = isFullScreen;
    }
    public void Resolution()
    {
        Screen.SetResolution(rsl[dropdown.value].width, rsl[dropdown.value].height, isFullScreen,rsl[dropdown.value].refreshRate);
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
        isFullScreen = Screen.fullScreen;
        togl.isOn = isFullScreen;
        Debug.Log(Screen.fullScreen);
    }
}
