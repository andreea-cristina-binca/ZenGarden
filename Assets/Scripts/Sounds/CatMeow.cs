using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMeow : MonoBehaviour
{
    public AudioClip meowOne;
    public AudioClip meowTwo;

    private float frequency;
    private float timePassed;

    void Start()
    {
        AudioSource.PlayClipAtPoint(meowOne, transform.position, 1f);
        frequency = Random.Range(60, 120);
        timePassed = 0;
    }

    void Update()
    {
        timePassed += Time.deltaTime;

        if (timePassed > frequency)
        {
            if (frequency % 2 == 0)
                AudioSource.PlayClipAtPoint(meowOne, transform.position, 1f);
            else
                AudioSource.PlayClipAtPoint(meowTwo, transform.position, 1f);

            frequency = Random.Range(100, 500);
            timePassed = 0;
        }
    }
}
