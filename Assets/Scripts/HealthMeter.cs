using UnityEngine;

public class HealthMeter : Meter
{
    public void UpdateHealthMeter(float value)
    {
        fillBar.fillAmount = value / 100;
    }
}
