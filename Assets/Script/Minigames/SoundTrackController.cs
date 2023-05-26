using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

[RequireComponent(typeof(Slider))]
public class SoundTrackController : MonoBehaviour
{

    Slider slider
    {
        get { return GetComponent<Slider>(); }
    }
    public AudioMixer mixer;
    [SerializeField]
    private Text volumeLabel;

    private void Start()
    {
        UpdateValueOnChange(slider.value);
        slider.onValueChanged.AddListener(delegate
        {
            UpdateValueOnChange(slider.value);
        });
    }
    public string volumeName;

    public void UpdateValueOnChange(float value)
    {
        if(mixer != null) 
        mixer.SetFloat(volumeName, Mathf.Log(value) * 20f);
        if (volumeLabel != null)
            volumeLabel.text = Mathf.Round(value * 100.0f).ToString() + "%";
    }
}
