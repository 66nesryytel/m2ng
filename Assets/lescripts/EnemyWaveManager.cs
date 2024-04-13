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

    public GameObject upgradeItem1;
   // public Vector2 spawnPosition1 = new Vector2 (4, 0);
    public GameObject upgradeItem2;
   // public Vector2 spawnPosition2 = new Vector2(5, 0);
    public GameObject upgradeItem3;
    //public Vector2 spawnPosition3 = new Vector2(6, 0);

    public bool enterpressed = true;


    private void Start()
    {
        // Start spawning waves
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        while (true)
        {

            if(Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                Instantiate(upgradeItem1, parentTransform);
                Instantiate(upgradeItem2, parentTransform);
                Instantiate(upgradeItem3, parentTransform);

                //  Increment the wave number
                currentWave++;

                if (currentWave % 3 == 0 && currentWave != 0) //tackshooter spawner
                {
                    Instantiate(tackshooter, tackPosition, Quaternion.identity);
                }


                //  Spawn enemies for the current wave
                StartCoroutine(SpawnEnemies(currentWave));

                yield return new WaitForSeconds(10);
            }
            yield return null;

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
