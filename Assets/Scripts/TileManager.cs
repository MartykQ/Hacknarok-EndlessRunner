using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{

    public GameObject[] tilesPrefabs;

    public State state;
    private Transform playerTransform;
    
    
    
    private float spawnZ = -13.0f;
    
    private float tileLength = 10.0f;
    
    private float safeZone = 6f+10.0f;
    
    
    //todo: ile ich musi być
    private int tilesCount = 5;
    
    private List<GameObject> tiles;
    private int lastPrefab = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        tiles = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        for (int i = 0; i < tilesCount; i++)
        {
            SpawnTile();
        }
 
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z -safeZone> (spawnZ - tilesCount * tileLength))
        {
            SpawnTile(randomPrefabIndex());
            DeleteTile();
        }
    }

    private void DeleteTile()
    {
        Destroy(tiles[0]);
        tiles.RemoveAt(0);
    }

    private void SpawnTile(int prefabIndex =-1)
    {
        if(prefabIndex ==-1)
        prefabIndex = randomPrefabIndex();
        
        GameObject go;
        go = Instantiate(tilesPrefabs[prefabIndex]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        tiles.Add(go);
    }

    private int randomPrefabIndex()
    {
        if (tilesPrefabs.Length <= 1)
            return 0;
        
        int randomIndex = Random.Range(0, tilesPrefabs.Length-1);

        if (randomIndex < lastPrefab)
        {
            lastPrefab = randomIndex;
            return randomIndex;
        }
       
        lastPrefab = randomIndex + 1;
        return randomIndex + 1;
        

    }
}
