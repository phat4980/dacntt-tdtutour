using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private List<Slider> backgroundSliders;
    [SerializeField] private List<Slider> SFXSliders;
    private float curBackgroundValue, curSFXValue = 1f;

    private void Start() {
        UpdateSliders();
    }

    public void UpdateSliders() {
        backgroundSliders.Clear();
        SFXSliders.Clear();

        GameObject[] gameObjects = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach (var sliderObject in gameObjects) {
            if (sliderObject.scene.name != null) {
                if (sliderObject.tag == "BackgroundSlider") {
                    Slider slider = sliderObject.GetComponent<Slider>();
                    if (slider != null) {
                        backgroundSliders.Add(slider);
                        slider.onValueChanged.AddListener(BackgroundVolumeChange);
                        slider.value = curBackgroundValue;
                    }
                }
                else if (sliderObject.tag == "SFXSlider") {
                    Slider slider = sliderObject.GetComponent<Slider>();
                    if (slider != null) {
                        SFXSliders.Add(slider);
                        slider.onValueChanged.AddListener(SFXVolumeChange);
                        slider.value = curSFXValue;
                    }
                }
            }
        }
    }

    public void BackgroundVolumeChange(float value) {
        SoundManager.Instance.backgroundVolume(value);
        foreach(var slider in backgroundSliders) {
            if (slider != null && slider.value != value) {
                slider.value = value;
            }
        }
    }

    public void SFXVolumeChange(float value) {
        SoundManager.Instance.SFXVolume(value);
        foreach(var slider in SFXSliders) {
            if (slider != null && slider.value != value) {
                slider.value = value;
            }
        }
    }
}