using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepSpawner : MonoBehaviour
{
    // Vars
    public bool canSpawn = true; 
    public GameObject sheepPrefab;
    public float timeBetweenSpawns;
    public List<Transform> sheepSpawnPositions = new List<Transform>(); 
    private List<GameObject> sheepList = new List<GameObject>();
    private int numSpawns;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize vars
        numSpawns = sheepSpawnPositions.Count;

        // Start spawn coroutine
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Other methods
    private void SpawnSheep()
    {
        // Get random spawn
        Vector3 spawnPosition = sheepSpawnPositions[Random.Range(0,numSpawns)].position; 

        // Create sheep instance
        GameObject sheep = Instantiate(sheepPrefab, spawnPosition, sheepPrefab.transform.rotation); 

        // Assign sheep spawner reference to the sheep instance
        sheep.GetComponent<Sheep>().SetSpawner(this);

        // Push back sheep instance to the list
        sheepList.Add(sheep);
    }

    private IEnumerator SpawnRoutine() 
    {
        while (canSpawn) 
        {
            SpawnSheep(); 
            yield return new WaitForSeconds(timeBetweenSpawns); 
        }
    }

    public void RemoveSheepFromList(GameObject sheep)
    {
        sheepList.Remove(sheep);
    }
}
