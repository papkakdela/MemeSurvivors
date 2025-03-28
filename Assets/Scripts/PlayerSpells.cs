using System.Collections;
using UnityEngine;

public class PlayerSpells : MonoBehaviour
{
    float waitForFireball;
    public void InitSpells()
    {
        waitForFireball = 0.5f;
        StartSpells();
    }

    public void StartSpells()
    {
        StartCoroutine(Fireball());
    }

    IEnumerator Fireball()
    {
        yield return new WaitForSeconds(waitForFireball);
        while (G.playerDamage.IsAlive())
        {
            if (G.enemySpawner.enemyExists())
                Instantiate(L.spells.fireballPrefab, G.playerTransform.position, Quaternion.identity);
            yield return new WaitForSeconds(waitForFireball);
        }
    }

}
