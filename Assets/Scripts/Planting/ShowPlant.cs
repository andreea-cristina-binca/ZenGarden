using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShowPlant : MonoBehaviour
{
    [SerializeField] private PlantSO plantObject;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject timerObject;

    private Transform plantTransform;
    private TimerManager timer;

    private void Start()
    {
        timer = timerObject.GetComponent<TimerManager>();
        timer.SetSeconds(plantObject.seconds);
        timer.SetMinutes(plantObject.minutes);
        timer.SetHours(plantObject.hours);
        //timer.timerSeconds = plantObject.seconds;
        //timer.timerMinutes= plantObject.minutes;
        //timer.timerHours = plantObject.hours;
        
        
        timerObject.SetActive(false);
    }

    public void Plant()
    {
        plantTransform = Instantiate(plantObject.prefab, spawnPoint);
        plantTransform.localPosition = Vector3.zero;

        timerObject.SetActive(true);

    }

    public void Harvest()
    {
        timerObject.SetActive(false);
    }
}
