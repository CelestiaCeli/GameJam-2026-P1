using UnityEngine;

public class HealthMeter : Meter
{
    public void UpdateHealthMeter(int value)
    {
        fillBar.fillAmount = value / 100;
    }
}
