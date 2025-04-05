using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject springMap;
    public GameObject summerMap;
    public GameObject autumnMap;
    public GameObject winterMap;

    public Material springMaterial;
    public Material summerMaterial;
    public Material autumnMaterial;
    public Material winterMaterial;

    public Material defaultPineMaterial;
    public Material winterPineMaterial;

    public string treeTag = "leaveTree";
    public string pineTag = "PineTree";


    void Start()
    {
        LoadMapBasedOnTime();
    }


    void LoadMapBasedOnTime()
    {
        int month = int.Parse(System.DateTime.UtcNow.ToLocalTime().ToString("MM"));
        //int month = 2;

        // Deactivate all maps initially
        springMap.SetActive(false);
        summerMap.SetActive(false);
        autumnMap.SetActive(false);
        winterMap.SetActive(false);

        switch (month)
        {
            case 12:
            case 1:
            case 2:
                SetWinter();
                break;
            case 3:
            case 4:
            case 5:
                SetSpring();
                break;
            case 6:
            case 7:
            case 8:
                SetSummer();
                break;
            case 9:
            case 10:
            case 11:
                SetAutumn();
                break;
            default:
                SetSummer();
                break;
        }
    }

    void SetWinter()
    {
        winterMap.SetActive(true);
        ApplySeasonalMaterial(treeTag, 1, winterMaterial);
        ApplySeasonalMaterial(pineTag, 0, winterPineMaterial);
    }
    void SetSpring()
    {
        springMap.SetActive(true);
        ApplySeasonalMaterial(treeTag, 1, springMaterial);
        ApplySeasonalMaterial(pineTag, 0, defaultPineMaterial);
    }
    void SetSummer()
    {
        summerMap.SetActive(true);
        ApplySeasonalMaterial(treeTag, 1, summerMaterial);
        ApplySeasonalMaterial(pineTag, 0, defaultPineMaterial);
    }
    void SetAutumn()
    {
        autumnMap.SetActive(true);
        ApplySeasonalMaterial(treeTag, 1, autumnMaterial);
        ApplySeasonalMaterial(pineTag, 0, defaultPineMaterial);
    }

    void ApplySeasonalMaterial(string tag, int matIndex, Material selectedMaterial)
    {
        GameObject[] trees = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject tree in trees)
        {
            Renderer[] renderers = tree.GetComponentsInChildren<Renderer>();
            foreach (Renderer renderer in renderers)
            {
                if (tag == "PineTree")
                {
                    renderer.material = selectedMaterial;
                }
                else if(tag == "leaveTree")
                {
                    Material[] materials = renderer.materials;
                    if (materials.Length > matIndex)
                    {
                        materials[matIndex] = selectedMaterial;
                        renderer.materials = materials;
                    }
                }
                else
                {
                    // Shouldn't reach here
                }
            }
        }
    }
}
