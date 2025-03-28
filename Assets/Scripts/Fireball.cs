using System.Collections;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float maxDistance;
    public float speed;

    private void Start()
    {
        var target = G.enemySpawner.GetClosestEnemy();
        StartCoroutine(Go(target.position - transform.position));
    }

    IEnumerator Go(Vector3 direction)
    {
        print("Started");
        direction = direction.normalized;

        Vector3 targetPosition = transform.position + direction * maxDistance;

        while (transform.position != targetPosition)
        {
            transform.position += direction * speed * Time.deltaTime;
            yield return null;
        }
    }
}
