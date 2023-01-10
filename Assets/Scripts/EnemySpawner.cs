using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemyPrefabs;
    
    private PlayerController player;

    [SerializeField]
    private float xRange = 10;

    private bool canSpawn = true;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn && player.IsAlive())
        {
            int index = Random.Range(0, enemyPrefabs.Length);
            Vector3 position = new Vector3(Random.Range(-xRange, xRange), 0, 0);
            Instantiate(enemyPrefabs[index], position + new Vector3(0,0.5f, 0), enemyPrefabs[index].transform.rotation);
            StartCoroutine(SpawnDelay());
        }
    }

    IEnumerator SpawnDelay()
    {
        canSpawn = false;
        yield return new WaitForSeconds(3);
        canSpawn = true;
    }
}