using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public float spawnRate = 1;
    private float timeleftBeforeSpawn = 0;
    private SpawnPoint[] spawnPoints;
    public GameObject[] ennemiPrefab;
	// Use this for initialization
	void Start () {
        spawnPoints = FindObjectsOfType<SpawnPoint>();
        timeleftBeforeSpawn = 1 / spawnRate;
	}
	
	// Update is called once per frame
	void Update () {
        UpdateSpawn();
	}

    private void UpdateSpawn()
    {
        timeleftBeforeSpawn -= Time.deltaTime;
        if (timeleftBeforeSpawn < 0)
        {
            SpawnCube();
            timeleftBeforeSpawn = 1 / spawnRate;
        }
    }

    private void SpawnCube()
    {
        int countSpawnPoint = spawnPoints.Length;
        int randomPointIndex = Random.Range(0, countSpawnPoint);
        SpawnPoint spawnRandomlySelect = spawnPoints[randomPointIndex];
        int randomEnnemiIndex = Random.Range(0, ennemiPrefab.Length);
        GameObject newCube = Instantiate(ennemiPrefab[randomEnnemiIndex], spawnRandomlySelect.GetPosition(), spawnRandomlySelect.transform.rotation);
    }
}
