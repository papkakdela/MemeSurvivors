using UnityEngine;
using static UnityEngine.ParticleSystem;

public class JoystickController : MonoBehaviour
{
    [SerializeField]
    int deadZoneRadius;

    [SerializeField]
    GameObject background;
    [SerializeField]
    GameObject handle;

    int handleMovementRadius = 50;

    Vector2 startPosition;

    [HideInInspector]
    public bool isControlling = false;
    [HideInInspector]
    public Vector2 direction;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            isControlling = true;
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startPosition = touch.position;
                    break;
                case TouchPhase.Moved:
                    break;
                case TouchPhase.Ended:
                    isControlling = false;
                    return;
                case TouchPhase.Stationary:
                    break;
                case TouchPhase.Canceled:
                    isControlling = false;
                    return;
            }
            var diff = direction - startPosition;

            direction = diff.magnitude > deadZoneRadius ? (touch.position - startPosition).normalized : Vector2.zero;
        }
        else
        {
            isControlling = false;
        }


        if (isControlling)
        {
            background.transform.position = startPosition;
            handle.transform.localPosition = direction * handleMovementRadius;
        }
        background.SetActive(isControlling);
        
    }
}
