using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public Collider2D col;
    public EnemyMovement movement;
    public Animator animator;
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Attack")
        {
            col.enabled = false;
            movement.enabled = false;
            var direction = (transform.position - G.playerTransform.position).normalized;
            rb.AddForce(direction * 1.5f, ForceMode2D.Impulse);
            StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        G.enemySpawner.RemoveEnemyFromActiveList(gameObject);

        yield return new WaitForSeconds(0.1f);
        

        animator.SetTrigger("Die");
        // play die animation
        yield return new WaitForSeconds(0.9f);

        gameObject.SetActive(false);
        G.enemySpawner.AddEnemyToTrash(gameObject);
    }
}
