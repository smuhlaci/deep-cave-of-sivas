using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGeneration : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnObjects;
    private GameObject rock;
    void Start()
    {
        int rand = Random.Range(0, spawnObjects.Length);
        rock = Instantiate(spawnObjects[rand], transform.position, Quaternion.identity);
        rock.transform.parent = gameObject.transform;
    }
}
