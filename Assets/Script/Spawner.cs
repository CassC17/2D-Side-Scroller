using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefabSpawn;

    void Start()
    {
        StartCoroutine(SpawnObjectIn5Seconds());
    }

    IEnumerator SpawnObjectIn5Seconds()
    {
        while (true)
        {
            SpawnGameObject();
            yield return new WaitForSeconds(5);
        }
    }

    void SpawnGameObject()
    {
        GameObject spawnedPrefab = Instantiate(prefabSpawn);
        spawnedPrefab.transform.position = new Vector3(0, 0, 0);
        spawnedPrefab.name = "Coucou";
        //spawnedPrefab.GetComponent<Movement>().speed = 20;
    }
}
