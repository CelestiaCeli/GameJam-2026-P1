using UnityEngine;

public class ChargeMeter : Meter
{
    public void UpdateChargeMeter(float value)
    {
        fillBar.fillAmount = value / 3;
    }
}
