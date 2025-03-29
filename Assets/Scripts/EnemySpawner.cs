using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    float minDistanceToPlayer;
    [SerializeField]
    float maxDistanceToPlayer;

    [HideInInspector]
    public bool isWaveInProgress = false;

    List<GameObject> spawnedEnemies = new List<GameObject>();
    List<GameObject> enemiesToRemove = new List<GameObject>();

    private void Start()
    {
        StartCoroutine(TrashCollector());
    }

    public IEnumerator StartFirstWave()
    {
        isWaveInProgress = true;
        spawnedEnemies.Add(SpawnEnemyAtRandomPosition());
        spawnedEnemies.Add(SpawnEnemyAtRandomPosition());
        spawnedEnemies.Add(SpawnEnemyAtRandomPosition());
        yield return new WaitForSeconds(3.0f);

        spawnedEnemies.Add(SpawnEnemyAtRandomPosition());
        spawnedEnemies.Add(SpawnEnemyAtRandomPosition());
        spawnedEnemies.Add(SpawnEnemyAtRandomPosition());

        yield return new WaitForSeconds(2.0f);

        spawnedEnemies.Add(SpawnEnemyAtRandomPosition());
        spawnedEnemies.Add(SpawnEnemyAtRandomPosition());
        spawnedEnemies.Add(SpawnEnemyAtRandomPosition());
        isWaveInProgress = false;
    }

    GameObject SpawnEnemyAtRandomPosition()
    {
        float angle = Random.Range(0, 2f * Mathf.PI);
        float distance = Random.Range(minDistanceToPlayer, maxDistanceToPlayer);

        Mathf.Sin(angle);
        Mathf.Cos(angle);

        return Instantiate(L.enemies.enemies[0], transform.position + new Vector3(Mathf.Sin(angle), Mathf.Cos(angle)) * distance, Quaternion.identity);
    }

    private void OnDrawGizmos()
    {
        Vector2 origin = transform.position;
        Handles.color = Color.green;
        Handles.DrawWireDisc(origin, new Vector3(0, 0, 1), minDistanceToPlayer);
        Handles.DrawWireDisc(origin, new Vector3(0, 0, 1), maxDistanceToPlayer);
    }

    public Transform GetClosestEnemy()
    {
        if (spawnedEnemies.Count == 0)
            return null;

        static float getDistance(Vector3 from, Vector3 to)
        {
            return (from - to).magnitude;
        }

        var player = G.playerTransform;
        var closestEnemy = spawnedEnemies[0].transform;
        var closestDist = getDistance(closestEnemy.position, player.position);

        
        foreach (var enemy in spawnedEnemies)
        {
            var enemyDist = getDistance(enemy.transform.position, player.position);
            if (enemyDist < closestDist)
            {
                closestDist = enemyDist;
                closestEnemy = enemy.transform;
            }
        }

        return closestEnemy;
    }

    public bool enemyExists()
    {
        return spawnedEnemies.Count > 0;
    }

    public void RemoveEnemyFromActiveList(GameObject i_enemy)
    {
        spawnedEnemies.Remove(i_enemy);
    }

    public void AddEnemyToTrash(GameObject i_enemy)
    {
        enemiesToRemove.Add(i_enemy);
    }

    public IEnumerator TrashCollector()
    {
        while (true)
        {
            foreach (var enemy in enemiesToRemove)
            {
                Destroy(enemy);
            }
            enemiesToRemove.Clear();
            yield return new WaitForSeconds(5);
        }
    }
}
