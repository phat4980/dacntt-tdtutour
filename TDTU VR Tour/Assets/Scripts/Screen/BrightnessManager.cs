using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class BrightnessManager : MonoBehaviour
{
    public Slider brightnessSlider;
    private Volume volume;
    private ColorAdjustments colorAdjustments;

    void Start()
    {
        volume = GetComponent<Volume>();
        if (volume.profile.TryGet<ColorAdjustments>(out var colorAdjustment))
        {
            colorAdjustments = colorAdjustment;
        }
        brightnessSlider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    public void OnSliderValueChanged(float value)
    {
        colorAdjustments.postExposure.value = value;
    }
}