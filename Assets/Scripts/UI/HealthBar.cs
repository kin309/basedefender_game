using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : ProgressBar
{
    public Slider delaySlider;

    public override void SetMaxFill(float value)
    {
        base.SetMaxFill(value);
        delaySlider.maxValue = value;
    }

    public override void SetFill(float value)
    {
        base.SetFill(value);
        StartCoroutine(DelayedFill(value));
    }

    public void InstantSetFill(float value)
    {
        base.SetFill(value);
        delaySlider.value = value;
    }

    public override void Set(float maxValue, float value)
    {
        SetMaxFill(maxValue);
        InstantSetFill(value);
    }

    public IEnumerator DelayedFill(float value)
    {
        yield return new WaitForSeconds(0.5f);
        delaySlider.value = value;
    }
}
