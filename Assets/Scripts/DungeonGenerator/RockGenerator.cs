using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class RockGenerator : MonoBehaviour
{
    [SerializeField] private int height,width;
    [SerializeField] private GameObject[] rockPrefabs;
    [SerializeField] private GameObject[] goldPrefabs;
    [SerializeField] private List<Vector3> tileWorldLocations;

    public Tilemap tilemap;

    void Start()
    {

        foreach (var pos in tilemap.cellBounds.allPositionsWithin)
        {
            Vector3Int localPlace = new Vector3Int(pos.x, pos.y, pos.z);
            Vector3 place = tilemap.CellToWorld(localPlace);
            if (!tilemap.HasTile(localPlace))
            {
                int gold = Random.Range(0, 25);
                if (gold <= 0)
                {
                    int rand = Random.Range(0, goldPrefabs.Length);
                    tileWorldLocations.Add(place);
                    Instantiate(goldPrefabs[rand], new Vector3(pos.x, pos.y, pos.z), Quaternion.identity);
                }
                else
                {
                    int rand = Random.Range(0, rockPrefabs.Length);
                    tileWorldLocations.Add(place);
                    Instantiate(rockPrefabs[rand], new Vector3(pos.x, pos.y, pos.z), Quaternion.identity);
                }
            }
        }
    }
}
