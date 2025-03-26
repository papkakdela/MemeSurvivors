using UnityEngine;

public class G : MonoBehaviour
{
    public static JoystickController joystick;
    public static Transform playerTransform;
    private void Awake()
    {
        joystick = GetComponent<JoystickController>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
