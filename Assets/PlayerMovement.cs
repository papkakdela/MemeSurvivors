using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Animator animator;

    Vector2 initialPosition;

    public InputManager inputManager;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        animator.SetBool("IsMoving", inputManager.movementDirection.magnitude != 0);
        if (inputManager.movementDirection.x < 0)
        {
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        }
        transform.position += new Vector3(inputManager.movementDirection.x, inputManager.movementDirection.y) * Time.fixedDeltaTime;
    }
}
