using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPlant : MonoBehaviour
{
    [SerializeField] private Transform plantPrefab;
    [SerializeField] private Transform spawnPoint;

    public void Interact()
    {
        Transform plantTransform = Instantiate(plantPrefab, spawnPoint);
        plantTransform.localPosition = Vector3.zero;
        
        // Debug.Log("Should spawn");
    }
}
