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

    public Transform parentTransform;

    public Camera mainCamera;

    public TackShooter tackshooter;
    public Vector2 tackPosition = new Vector2(-3, 0);
    public Vector2 tackPosition2 = new Vector2(0, 0);
    public Vector2 tackPosition3 = new Vector2(3, 0);

    public Vector2 suurPosition = new Vector2(2, 0);
    public Vector2 suurPosition2 = new Vector2(-2, 0);

    public GameObject suurVaenlane;

    public GameObject upgradeItem1;
    public GameObject upgradeItem2;
    public GameObject upgradeItem3;


    private void Start()
    {
        // Start spawning waves
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        while (true)
        {
            GameObject item1 = Instantiate(upgradeItem1, parentTransform);
            GameObject item2 = Instantiate(upgradeItem2, parentTransform);
            GameObject item3 = Instantiate(upgradeItem3, parentTransform);




            //  Increment the wave number
            currentWave++;

            if (currentWave == 3 || currentWave == 9 || currentWave == 12) //tackshooter spawner
            {
                if (currentWave == 3)
                {
                    Instantiate(tackshooter, tackPosition, Quaternion.identity);
                }
                else if (currentWave == 9)
                {
                    Instantiate(tackshooter, tackPosition2, Quaternion.identity);
                }
                else if (currentWave == 12)
                {
                    Instantiate(tackshooter, tackPosition3, Quaternion.identity);
                }
            }

            if (currentWave > 5)
            {
                Instantiate(suurVaenlane);
            }
            else if (currentWave > 10)
            {
                Instantiate(suurVaenlane, suurPosition, Quaternion.identity);
                Instantiate(suurVaenlane, suurPosition2, Quaternion.identity);
            }


            //  Spawn enemies for the current wave
            StartCoroutine(SpawnEnemies(currentWave));

            yield return new WaitForSeconds(10);

            if (item1 != null && item2 != null && item3 != null)
            {
                Destroy(item1);
                Destroy(item2);
                Destroy(item3);
            }
        }

        IEnumerator SpawnEnemies(int waveNumber)
        {
            for (int i = 0; i < enemiesPerWave * Mathf.Pow(2f, waveNumber); i++)
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
}
