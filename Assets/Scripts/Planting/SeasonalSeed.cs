using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeasonalSeed : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject evenMonthPrefab;
    [SerializeField] private GameObject oddMonthPrefab;

    [Header("Sprites")]
    [SerializeField] private Sprite evenMonthSprite;
    [SerializeField] private Sprite oddMonthSprite;

    public GameObject SelectedPrefab { get; private set; }
    public Sprite SelectedSprite { get; private set; }

    private void Awake()
    {
        int currentMonth = 1;

        bool isEven = currentMonth % 2 == 0;

        SelectedPrefab = isEven ? evenMonthPrefab : oddMonthPrefab;
        SelectedSprite = isEven ? evenMonthSprite : oddMonthSprite;
    }
}
