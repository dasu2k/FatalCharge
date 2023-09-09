using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject targetToSpawn;
    // Start is called before the first frame update
    public float spawnInterval;
    // Update is called once per frame
    void Start()
    {
        StartCoroutine(spawnEnemy(spawnInterval, targetToSpawn));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, transform.position + new Vector3(Random.Range(-5f, 5), Random.Range(-6f, 6f),Random.Range(0f, -4f)), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }

}
