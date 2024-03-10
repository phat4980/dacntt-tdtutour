using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrightnessManager : MonoBehaviour
{
    public List<Slider> brightnessSliders;
    private float currentBrightness = 1f;

    private void Start()
    {
        UpdateSliders();
    }

    public void UpdateSliders() {
        brightnessSliders.Clear();
        GameObject[] gameObj = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach (var sliderObj in gameObj) {
            if (sliderObj.scene.name != null) {
                if (sliderObj.CompareTag("BrightnessSlider"))
                {
                    Slider slider = sliderObj.GetComponent<Slider>();
                    brightnessSliders.Add(slider);
                    slider.onValueChanged.AddListener(ChangeBrightness);
                    slider.value = currentBrightness;
                }
            }
        }
    }

    public void ChangeBrightness(float brightness) {
        currentBrightness = brightness;
        RenderSettings.ambientIntensity = brightness;

        if (RenderSettings.skybox.HasProperty("_Exposure")) {
            RenderSettings.skybox.SetFloat("_Exposure", brightness);
            DynamicGI.UpdateEnvironment();
        }

        foreach (var slider in brightnessSliders) {
            if (slider.value != brightness) {
                slider.value = brightness;
            }
        }
    }
}