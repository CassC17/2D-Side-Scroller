using UnityEngine;

public class ObstaclesSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclesPrefabs;

    public float obstacleSpawnTime = 2f;
    public float obstacleSpeed = 2f;

    private float timeUntilSpawn;

    private void Update()
    {
        SpawnLoop();
    }

    private void SpawnLoop()
    {
        timeUntilSpawn += Time.deltaTime;

        if (timeUntilSpawn >= obstacleSpawnTime)
        {
            Spawn();
            timeUntilSpawn = 0;
        }
    }

    private void Spawn()
    {
        GameObject obstacleToSpawn = obstaclesPrefabs[Random.Range(0, obstaclesPrefabs.Length)];

        //spawn with the prefab rotation
        GameObject spawnedObstacle = Instantiate(obstacleToSpawn, transform.position, Quaternion.identity);

        ObstacleMove mover = spawnedObstacle.GetComponent<ObstacleMove>();
        if (mover == null)
        {
            mover = spawnedObstacle.AddComponent<ObstacleMove>();
        }

        mover.speed = obstacleSpeed; ;
    }
}
