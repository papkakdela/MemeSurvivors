using UnityEngine;

public class G : MonoBehaviour
{
    public static JoystickController joystick;

    private void Awake()
    {
        joystick = GetComponent<JoystickController>();
    }
}
