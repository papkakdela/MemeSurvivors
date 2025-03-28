using UnityEngine;
using static UnityEngine.Rendering.RayTracingAccelerationStructure;
using UnityEngine.InputSystem;

public class L : MonoBehaviour
{
    public static CharacterLibrary characters;
    public static EnemyLibrary enemies;
    public static SpellLibrary spells;

    private void Awake()
    {
        characters = GetComponent<CharacterLibrary>();
        enemies = GetComponent<EnemyLibrary>();
        spells = GetComponent<SpellLibrary>();
    }
}
