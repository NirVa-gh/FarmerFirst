using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] AnimalArray;
    private int AnimalIndex;
    private Vector3 PositionOfAnimal;
    public float timeOfCircle = 2.0f;
    void Start()
    {
        InvokeRepeating("SpawnAnimal", 3.4f, timeOfCircle);
    }
    void SpawnAnimal()
    {
        print("Spawn");
        AnimalIndex = Random.Range(0, AnimalArray.Length);
        PositionOfAnimal = new Vector3(Random.Range(-25, 25), 0, 30);
        Instantiate(AnimalArray[AnimalIndex], PositionOfAnimal, AnimalArray[AnimalIndex].transform.rotation);
    }

}