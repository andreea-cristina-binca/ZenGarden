using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShowPlant : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject timerObject;
    [SerializeField] private PlantSO plantStartObject;
    [SerializeField] private PlantSO tulipPlant;
    [SerializeField] private PlantSO rosePlant;
    [SerializeField] private PlantSO daffodilPlant;
    [SerializeField] private PlantSO yellowCorePlant;

    private PlantSO plantObject;
    private Transform plantTransform;
    private TimerManager timer;
    private bool planted;
    private bool harvestable;

    private void Start()
    {
        timer = timerObject.GetComponent<TimerManager>();

        timerObject.SetActive(false);
        planted = false;
        harvestable = false;
    }

    private void Update()
    {
        if (planted)
        {
            if (timer.GetHoursLeft() == 0 && timer.GetMinutesLeft() == 0 && timer.GetSecondsLeft() == 0)
            {
                Destroy(plantTransform.gameObject);

                plantTransform = Instantiate(plantObject.prefab, spawnPoint);
                plantTransform.localPosition = Vector3.zero;

                planted = false;
                harvestable = true;
            }
        }

        if (plantTransform == null)
        {
            timerObject.SetActive(false);
        }
    }

    public GameObject Interact(GameObject isHolding)
    {
        if (isHolding)
        {
            switch (isHolding.tag)
            {
                case "Tulip":
                    plantObject = tulipPlant;
                    break;
                case "Rose":
                    plantObject = rosePlant;
                    break;
                case "Daffodil":
                    plantObject = daffodilPlant;
                    break;
                case "YellowCore":
                    plantObject = yellowCorePlant;
                    break;
                default:
                    break;
            }

            if (!planted && !harvestable)
            {
                if (Plant())
                {
                    Debug.Log("Planted");
                    Destroy(isHolding.gameObject);
                }
            }
        }

        if (harvestable)
        {
            if(Harvest())
                Debug.Log("Harvested");
        }

        return isHolding;
    }

    public bool Plant()
    {
        if (planted == false)
        {
            plantTransform = Instantiate(plantStartObject.prefab, spawnPoint);
            plantTransform.localPosition = Vector3.zero;

            timer.SetSeconds(plantObject.seconds);
            timer.SetMinutes(plantObject.minutes);
            timer.SetHours(plantObject.hours);
            timerObject.SetActive(true);
            planted = true;
            harvestable = false;

            return true;
        }

        return false;
    }

    public bool Harvest()
    {
        if (harvestable == true)
        {
            if (timer.GetHoursLeft() == 0 && timer.GetMinutesLeft() == 0 && timer.GetSecondsLeft() == 0)
            {
                //Destroy(plantTransform.gameObject);

                timerObject.SetActive(false);
                planted = false;
                harvestable = false;

                //Debug.Log(plantTransform.gameObject);

                return true;
            }
        }

        return false;
    }
}
