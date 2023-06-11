using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantsAndSeeds : MonoBehaviour
{
    public static PlantsAndSeeds Instance { get; private set; }

    public GameObject tulipSeed;
    public GameObject roseSeed;
    public GameObject daffodilSeed;
    public GameObject yellowCoreSeed;

    public PlantSO tulipPlant;
    public PlantSO rosePlant;
    public PlantSO daffodilPlant;
    public PlantSO yellowCorePlant;
}
