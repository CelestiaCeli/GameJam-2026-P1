using UnityEngine;

public class ChargeMeter : Meter
{
    public void UpdateChargeMeter(float value)
    {
        float chargeAmount = value / 3;
        fillBar.fillAmount = chargeAmount;
    }
}
