using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemyspawner : MonoBehaviour
{
    public GameObject vaenlane;
    public GameObject player;
    public float kaugus_mangijast;
    public float spawnInterval;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    public IEnumerator SpawnObjects()
    {
        while (true)
        {
            Vector2 spawnPosition = GetRandomSpawnPosition();
            Instantiate(vaenlane, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    Vector2 GetRandomSpawnPosition()
    {
        float suvaline_x = Random.Range(player.transform.position.x - kaugus_mangijast, player.transform.position.x + kaugus_mangijast);
        float suvaline_y = Random.Range(player.transform.position.y - kaugus_mangijast, player.transform.position.y + kaugus_mangijast);
        return new Vector2(suvaline_x, suvaline_y);
    }
}
