using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Animator animator;

    float speed = 2;

    PlayerDamage playerDamage;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerDamage = GetComponent<PlayerDamage>();
    }

    void Update()
    {
        if (!playerDamage.IsAlive())
        {
            animator.SetBool("IsMoving", false);
            return;
        }

        animator.SetBool("IsMoving", G.joystick.isControlling);
        if (!G.joystick.isControlling)
            return;

        var direction = G.joystick.direction;
        if (direction.x < 0)
        {
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        }
        transform.position += new Vector3(direction.x, direction.y) * Time.deltaTime * speed;
    }
}
