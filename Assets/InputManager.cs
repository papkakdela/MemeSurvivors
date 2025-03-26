using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class InputManager : MonoBehaviour
{
    [HideInInspector]
    public Vector2 movementDirection;

    Vector2 initialPosition;

    public Camera cam;

    public GameObject background;
    public GameObject stick;

    int stickMovementRadius = 25;


    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            var touchPositionInWorld = cam.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, cam.nearClipPlane));
            var touchPosition = new Vector2(touchPositionInWorld.x, touchPositionInWorld.y);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    background.transform.position = touch.position;
                    background.SetActive(true);
                    initialPosition = touchPosition;
                    break;
                case TouchPhase.Moved:
                    break;
                case TouchPhase.Ended:
                    background.SetActive(false);
                    ClearMovementDirection();
                    return;
                case TouchPhase.Stationary:
                    break;
                case TouchPhase.Canceled:
                    background.SetActive(false);
                    ClearMovementDirection();
                    return;
            }
            if ((initialPosition - touchPosition).magnitude < 0.1)
                ClearMovementDirection();
            else
                FillMovementDirection(touchPosition, touch.position);
        }
        else
        {
            ClearMovementDirection();
        }
    }

    void ClearMovementDirection()
    {
        movementDirection = Vector2.zero;
        stick.transform.position = background.transform.position;
        //background.enabled = false;
    }

    void FillMovementDirection(Vector2 i_touchPosition, Vector2 i_touchPositionInScreen)
    {
        movementDirection = (i_touchPosition - initialPosition).normalized;
        stick.transform.position = stickMovementRadius * movementDirection;
        stick.transform.position += background.transform.position;
        //background.enabled = true;
    }
}
