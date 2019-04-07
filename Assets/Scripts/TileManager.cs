using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{

    public GameObject[] tilesNonFatalPrefabs;
    public GameObject[] tilesEasyPrefabs;
    public GameObject[] tilesMediumPrefabs;
    public GameObject[] tilesHardPrefabs;


    public State state;
    private Transform playerTransform;
    
    
    
    private float spawnZ = -13.0f;
    
    private float tileLength = 10.0f;
    
    private float safeZone = 6f+10.0f;
    
    
    //todo: ile ich musi być
    private int tilesCount = 14;
    
    private List<GameObject> tiles;
    private int lastPrefab = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        tiles = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        for (int i = 0; i < tilesCount; i++)
        {
            if(i<5)
            SpawnTile(randomPrefabIndex(0), 0);
            else
            {
                SpawnTile(randomPrefabIndex(state.difficulty),state.difficulty);
            }
        }
 
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z -safeZone> (spawnZ - tilesCount * tileLength))
        {
           
            SpawnTile(randomPrefabIndex(state.difficulty),state.difficulty);
            DeleteTile();
        }
    }

    private void DeleteTile()
    {
        Destroy(tiles[0]);
        tiles.RemoveAt(0);
    }

    private GameObject[] tileset(int difficulty)
    {
        switch (difficulty)
        {
            default:
                Debug.Log("bad difficulty");
                return tilesNonFatalPrefabs;
            case 0:
                return tilesNonFatalPrefabs;
            case 1:
                return tilesEasyPrefabs;
            case 2:
                return tilesMediumPrefabs;
            case 3:
                return tilesHardPrefabs;
        }

    }

    private void SpawnTile(int prefabIndex ,int difficulty)
    {        
       
        GameObject go;
        go = Instantiate(tileset(difficulty)[prefabIndex]);
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        tiles.Add(go);
    }

    private int randomPrefabIndex(int difficulty)
    {
        int len = tileset(difficulty).Length;
        if (len <= 1)
            return 0;
        
        int randomIndex = Random.Range(0, len-1);

        if (randomIndex < lastPrefab)
        {
            lastPrefab = randomIndex;
            return randomIndex;
        }
       
        lastPrefab = randomIndex + 1;
        return randomIndex + 1;
        

    }
}
