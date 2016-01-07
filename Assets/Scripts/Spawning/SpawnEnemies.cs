using UnityEngine;
using System.Collections;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject enemyUnit;
    public Transform[] spawnPoints;

    private float _spawnDelay;


    // Use this for initialization
    void Start ()
    {
        _spawnDelay = 2;

        StartCoroutine(SpawnEnemy());
	}
	
    IEnumerator SpawnEnemy()
    {
        //let it loop
        while (true)
        {
            //picks random spawnpoint
            GameObject enemyClone = (GameObject)Instantiate(enemyUnit, spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position, Quaternion.identity);

            //wait for new spawn
            yield return new WaitForSeconds(_spawnDelay);
        }
    }
}
