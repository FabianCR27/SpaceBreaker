using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class settingMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public AudioMixer audioMixer2;
  public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }
    public void SetVolume2(float volume2)
    {
        audioMixer2.SetFloat("VolumeEffects", volume2);
    }
}
