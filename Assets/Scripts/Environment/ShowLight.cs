using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowLight : MonoBehaviour
{
    [SerializeField] private Material lightOff;
    [SerializeField] private Material lightOn;

    private Material[] materials;
    private bool isNight;
    
    void Start()
    {
        ChangeLightMaterial(lightOff);
        isNight = false;
    }

    void Update()
    {
        if (!isNight && (Clock.ClockHour >= 19 || Clock.ClockHour < 7))
        {
            ChangeLightMaterial(lightOn);
            isNight = true;
        }
        
        if (isNight && (Clock.ClockHour < 19 && Clock.ClockHour >= 7))
        {
            ChangeLightMaterial(lightOff);
            isNight = false;
        }
    }

    private void ChangeLightMaterial(Material light)
    {
        materials = GetComponent<Renderer>().materials;
        materials[2] = light;
        gameObject.GetComponent<Renderer>().materials = materials;
    }
}
