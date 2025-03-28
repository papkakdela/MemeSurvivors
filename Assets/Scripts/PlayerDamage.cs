using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    int maxHealth = 100;
    int health;

    GameObject damagedColor;

    List<GameObject> collisionObjects = new List<GameObject>();

    private void Awake()
    {
        damagedColor = transform.GetChild(0).gameObject;
        health = maxHealth;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collisionObjects.Add(collision.gameObject);
            damagedColor.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collisionObjects.Remove(collision.gameObject);
            if (collisionObjects.Count == 0)
                damagedColor.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        if (collisionObjects.Count > 0)
        {
            health -= 1;
            //print(health);
        }
    }

    public bool IsAlive()
    {
        return health > 0;
    }

    public void RestoreHealth()
    {
        health = maxHealth;
    }
}
