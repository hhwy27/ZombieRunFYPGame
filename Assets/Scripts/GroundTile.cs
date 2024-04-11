using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    Ground groundSpawner;
    [SerializeField] GameObject SpikesPrefab;
    [SerializeField] GameObject BrainsPrefab;
    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<Ground>();
        SpawnObstacle();
        SpawnBrains();
    }

    //private void OnTriggerExit (Collider other)
    //{
        //groundSpawner.SpawnTile(true);
        //Destroy(gameObject, 2);
    //}

    public void SpawnObstacle ()
    {
        // Choose a random point to spawn the obstacle
        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        // Spawn the obstace at the position
        Instantiate(SpikesPrefab, spawnPoint.position, Quaternion.identity, transform);
    }

    public void SpawnBrains ()
    {
        int NuNewBrains = 3;
        for (int i = 0; i < NuNewBrains; i++) {
            GameObject temp = Instantiate(BrainsPrefab, transform);
            temp.transform.position = GetRandomPointInFloor(GetComponent<Collider>());
        }
    }

        Vector3 GetRandomPointInFloor (Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
            );
        if (point != collider.ClosestPoint(point)) {
            point = GetRandomPointInFloor(collider);
        }

        point.y = 1;
        return point;
    }



    // Update is called once per frame
    void Update()
    {
        
    }




}
