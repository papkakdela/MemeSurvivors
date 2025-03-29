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

        float distance = 0;

        while (distance < maxDistance)
        {
            var movement = direction * speed * Time.deltaTime;
            transform.position += movement;
            distance += movement.magnitude;
            yield return null;
        }
        Destroy(gameObject);
    }
}
