using UnityEngine;

public class G : MonoBehaviour
{
    public static JoystickController joystick;
    public static Transform playerTransform;
    public static UiManager ui;
    public static Main main;

    private void Awake()
    {
        joystick = GetComponent<JoystickController>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        ui = GetComponent<UiManager>();
        main = GetComponent<Main>();
    }

    private void FixedUpdate()
    {
        transform.position = playerTransform.position;
    }
}
