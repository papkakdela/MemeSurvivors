using UnityEngine;

public class G : MonoBehaviour
{
    // Managers
    public static JoystickController joystick;
    public static UiManager ui;
    public static Main main;
    public static EnemySpawner enemySpawner;
    public static RunSettings runSettings;

    // Run scope
    public static Transform playerTransform;
    public static PlayerDamage playerDamage;

    private void Awake()
    {
        joystick = GetComponent<JoystickController>();
        ui = GetComponent<UiManager>();
        main = GetComponent<Main>();
        enemySpawner = GetComponent<EnemySpawner>();
        runSettings = GetComponent<RunSettings>();
    }

    public static void InitPlayer()
    {
        var playerGO = GameObject.FindGameObjectWithTag("Player");
        playerTransform = playerGO.transform;
        playerDamage = playerGO.GetComponent<PlayerDamage>();
    }

    private void FixedUpdate()
    {
        if (playerTransform != null)
            transform.position = playerTransform.position;
    }
}
