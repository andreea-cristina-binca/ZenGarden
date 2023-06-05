using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField] private PlantSO plantSO;

    public PlantSO GetPlantSO() 
    { 
        return plantSO; 
    }
}
