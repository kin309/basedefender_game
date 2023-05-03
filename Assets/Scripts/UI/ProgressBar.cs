using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Slider slider;

    public virtual void SetMaxFill(float value)
    {
        slider.maxValue = value;
    }

    public virtual void SetFill(float value)
    {
        slider.value = value;
    }

    public virtual void Set(float maxValue, float value)
    {
        SetMaxFill(maxValue);
        SetFill(value);
    }


}
