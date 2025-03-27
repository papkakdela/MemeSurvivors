using System.Collections;
using UnityEditor;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    float minDistanceToPlayer;
    [SerializeField]
    float maxDistanceToPlayer;

    public IEnumerator StartFirstWave()
    {
        SpawnEnemyAtRandomPosition();
        SpawnEnemyAtRandomPosition();
        SpawnEnemyAtRandomPosition();
        yield return new WaitForSeconds(3.0f);

        SpawnEnemyAtRandomPosition();
        SpawnEnemyAtRandomPosition();
        SpawnEnemyAtRandomPosition();

        yield return new WaitForSeconds(2.0f);

        SpawnEnemyAtRandomPosition();
        SpawnEnemyAtRandomPosition();
        SpawnEnemyAtRandomPosition();
    }

    GameObject SpawnEnemyAtRandomPosition()
    {
        return Instantiate(L.enemies.enemies[0]);
    }

    private void OnDrawGizmos()
    {
        Vector2 origin = transform.position;
        Handles.color = Color.green;
        Handles.DrawWireDisc(origin, new Vector3(0, 0, 1), minDistanceToPlayer);
        Handles.DrawWireDisc(origin, new Vector3(0, 0, 1), maxDistanceToPlayer);
    }
}
