using System.Collections;
using UnityEngine;

public class EnemyWaveManager : MonoBehaviour
{
    public GameObject vaenlane; // Reference to the enemy prefab to spawn
    public float timeBetweenWaves = 10f; // Time between each wave
    public int enemiesPerWave = 10; // Number of enemies per wave
    public int currentWave = 0; // Current wave number

    public GameObject player;
    public float spawnInterval = 1f;
    public float spawnDistance = 10f;

    public Camera mainCamera;

    private void Start()
    {
        // Start spawning waves
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenWaves);

            // Increment the wave number
            currentWave++;

            // Spawn enemies for the current wave
            StartCoroutine(SpawnEnemies(currentWave));
        }
    }

    IEnumerator SpawnEnemies(int waveNumber)
    {
        for (int i = 0; i < enemiesPerWave*Mathf.Pow(2f,waveNumber); i++)
        {
            // Spawn enemies with some offset
            Vector3 spawnPosition = GetRandomSpawnPosition();

            if (isOffScreen(spawnPosition) && spawnPosition.x < 11f && spawnPosition.x > -8f && spawnPosition.y < 7.6f && spawnPosition.y > -6.4f)
            {
                Instantiate(vaenlane, spawnPosition, Quaternion.identity);
            }

            yield return new WaitForSeconds(spawnInterval);

        }
    }


    Vector3 GetRandomSpawnPosition()
    {
        Vector3 cameraPosition = mainCamera.transform.position;

        Vector3 spawnPoint = cameraPosition;

        spawnPoint.y += Random.Range(-spawnDistance, spawnDistance);
        spawnPoint.x += Random.Range(-spawnDistance, spawnDistance);
        spawnPoint.z -= 2;

        return spawnPoint;
        
    }

    bool isOffScreen(Vector2 position)
    {
        Vector3 viewportPoint = mainCamera.WorldToViewportPoint(position);

        return (viewportPoint.x < 0 || viewportPoint.x > 1 || viewportPoint.y < 0 || viewportPoint.y > 1);
    }

}
