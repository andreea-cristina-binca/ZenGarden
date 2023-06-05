using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class PlantSO : ScriptableObject
{
    public string objectName;
    public Transform prefab;
    // public Sprite sprite;

    public int seconds;
    public int minutes;
    public int hours;
}
