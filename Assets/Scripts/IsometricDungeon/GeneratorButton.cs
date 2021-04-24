using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorButton : MonoBehaviour
{
    [SerializeField] private GameObject[] dungeonPrefabs;
    [SerializeField] private List<GameObject> insantiatedDungeons;
    private GameObject currentMap;
    private int index = 0;
    void Start()
    {
        int rand = Random.Range(0, dungeonPrefabs.Length);
        currentMap = Instantiate(dungeonPrefabs[rand], new Vector3(0, 0, 0), Quaternion.identity);
        insantiatedDungeons.Add(currentMap);
    }

    public void GenerateMap()
    {
        insantiatedDungeons[index].SetActive(false);
        int rand = Random.Range(0, dungeonPrefabs.Length);
        currentMap = Instantiate(dungeonPrefabs[rand], new Vector3(0, 0, 0), Quaternion.identity);
        insantiatedDungeons.Add(currentMap);
        index +=1 ;
    }
}
