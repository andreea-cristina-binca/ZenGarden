using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherManager : MonoBehaviour
{
    public enum WeatherType
    {
        Sunny,
        Rainy,
        Cloudy,
        Snowy
    }

    [SerializeField] private Light directionalLight;
    [SerializeField] private GameObject sunnyClouds, rainyClouds;
    [SerializeField] private ParticleSystem rainEffect, snowEffect;

    private WeatherType currentWeather;

    // Start is called before the first frame update
    void Start()
    {
        int month = int.Parse(System.DateTime.UtcNow.ToLocalTime().ToString("MM"));
        var rnd = new System.Random();
        int val = rnd.Next(1, 4);

        switch (val)
        {
            case 1:
                currentWeather = WeatherType.Sunny;
                break;
            case 2:
                currentWeather = WeatherType.Rainy;
                break;
            case 3:
                currentWeather = WeatherType.Cloudy;
                break;
            case 4:
                {
                    if (month == 12 || month == 1 || month == 2)
                        currentWeather = WeatherType.Snowy;
                    else
                        currentWeather = WeatherType.Sunny;
                } 
                break;
            default:
                currentWeather = WeatherType.Sunny;
                break;
        }

        Debug.Log(Clock.DateMonth);
        ChangeWeather(currentWeather); // Start with picked weather
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeWeather(WeatherType newWeather)
    {
        currentWeather = newWeather;

        // Update visuals based on weather
        switch (currentWeather)
        {
            case WeatherType.Sunny:
                rainyClouds.SetActive(false);
                sunnyClouds.SetActive(true);
                //directionalLight.intensity = 1.0f;
                rainEffect.Stop();
                snowEffect.Stop();
                break;

            case WeatherType.Rainy:
                sunnyClouds.SetActive(false);
                rainyClouds.SetActive(true);
                //directionalLight.intensity = 0.6f;
                rainEffect.Play();
                snowEffect.Stop();
                break;

            case WeatherType.Snowy:
                sunnyClouds.SetActive(false);
                rainyClouds.SetActive(true);
                //directionalLight.intensity = 0.8f;
                rainEffect.Stop();
                snowEffect.Play();
                break;

            case WeatherType.Cloudy:
                sunnyClouds.SetActive(false);
                rainyClouds.SetActive(true);
                //directionalLight.intensity = 0.5f;
                rainEffect.Stop();
                snowEffect.Stop(); 
                break;
        }
    }
}
