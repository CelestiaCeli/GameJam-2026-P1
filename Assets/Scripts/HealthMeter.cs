using UnityEngine;

public class HealthMeter : Meter
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealthMeter(int value)
    {
        fillBar.fillAmount = value / 100;
    }
}
