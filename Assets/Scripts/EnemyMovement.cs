using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Transform target;
    float speed = 1;
    public float spawnTime;
    float closeEnough = 0.2f;

    private void Start()
    {
        target = G.playerTransform;
    }

    void FixedUpdate()
    {
        if (spawnTime > 0 || target == null)
        {
            spawnTime -= Time.fixedDeltaTime;
        }
        else
        {
            var diff = target.position - transform.position;
            var direction = (target.position - transform.position).normalized;
            if (direction.x < 0)
            {
                transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
            }
            else
            {
                transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
            }
            
            if (diff.magnitude > closeEnough)
                transform.position += new Vector3(direction.x, direction.y) * Time.fixedDeltaTime * speed;
        }
    }
}
