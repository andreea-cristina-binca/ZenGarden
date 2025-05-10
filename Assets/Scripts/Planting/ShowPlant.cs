using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShowPlant : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject timerObject;
    [SerializeField] private PlantSO plantSeedObject;
    [SerializeField] private PlantSO plantLeafObject;
    [SerializeField] private PlantSO plantStemObject;
    [SerializeField] private PlantSO tulipPlant;
    [SerializeField] private PlantSO rosePlant;
    [SerializeField] private PlantSO daffodilPlant;
    [SerializeField] private PlantSO yellowCorePlant;
    [SerializeField] private PlantSO lillyPlant;
    [SerializeField] private PlantSO sunflowerPlant;
    [SerializeField] private PlantSO snowdropPlant;
    [SerializeField] private PlantSO poinsettiaPlant;

    private PlantSO plantObject;
    private Transform plantTransform;
    private TimerManager timer;
    private bool planted;
    private bool harvestable;
    private bool hasSpawnedAtOneThird;
    private bool hasSpawnedAtTwoThirds;

    private void Start()
    {
        timer = timerObject.GetComponent<TimerManager>();

        timerObject.SetActive(false);
        planted = false;
        harvestable = false;
        hasSpawnedAtOneThird = false;
        hasSpawnedAtTwoThirds = false;
    }

    private void Update()
    {
        if (planted)
        {
            float totalSeconds = (plantObject.hours * 3600) + (plantObject.minutes * 60) + plantObject.seconds;
            float secondsLeft = (timer.GetHoursLeft() * 3600) + (timer.GetMinutesLeft() * 60) + timer.GetSecondsLeft();

            // Check 1/3
            if (!hasSpawnedAtOneThird && secondsLeft <= (2f / 3f) * totalSeconds)
            {
                Destroy(plantTransform.gameObject);
                plantTransform = Instantiate(plantLeafObject.prefab, spawnPoint);
                plantTransform.localPosition = Vector3.zero;

                hasSpawnedAtOneThird = true;
            }

            // Check 2/3
            if (!hasSpawnedAtTwoThirds && secondsLeft <= (1f / 3f) * totalSeconds)
            {
                Destroy(plantTransform.gameObject);
                plantTransform = Instantiate(plantStemObject.prefab, spawnPoint);
                plantTransform.localPosition = Vector3.zero;

                hasSpawnedAtTwoThirds = true;
            }

            // Check if timer is done
            if (secondsLeft <= 0)
            {
                Destroy(plantTransform.gameObject);
                plantTransform = Instantiate(plantObject.prefab, spawnPoint);
                plantTransform.localPosition = Vector3.zero;

                planted = false;
                harvestable = true;
                hasSpawnedAtOneThird = false;
                hasSpawnedAtTwoThirds = false;
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
                case "Lilly":
                    plantObject = lillyPlant;
                    break;
                case "Sunflower":
                    plantObject = sunflowerPlant;
                    break;
                case "Snowdrop":
                    plantObject = snowdropPlant;
                    break;
                case "Poinsettia":
                    plantObject = poinsettiaPlant;
                    break;
                default:
                    break;
            }

            if (!planted && !harvestable)
            {
                if (Plant())
                {
                    // Debug.Log("Planted");
                    Destroy(isHolding.gameObject);
                    isHolding = null;
                }
            }
        }

        if (harvestable)
        {
            if (Harvest())
            {
                // Debug.Log("Harvested");
            }
        }

        return isHolding;
    }

    public bool Plant()
    {
        if (planted == false)
        {
            plantTransform = Instantiate(plantSeedObject.prefab, spawnPoint);
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
                timerObject.SetActive(false);
                planted = false;
                harvestable = false;

                return true;
            }
        }

        return false;
    }
}
