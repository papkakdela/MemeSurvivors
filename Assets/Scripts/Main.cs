using System.Collections;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class Main : MonoBehaviour
{
    private void Start()
    {
        // start game
        // spawn hero
        StartCoroutine(StartNewGame());

    }

    IEnumerator StartNewGame() 
    {
        int selectedCharacterId = G.runSettings.characterId;
        var character = Instantiate(L.characters.characters[selectedCharacterId], transform.position, Quaternion.identity);
        G.InitPlayer();

        yield return new WaitUntil(() => G.joystick.isControlling);
        G.ui.HideStartRun();

        while (G.playerDamage.IsAlive())
            yield return StartCoroutine(G.enemySpawner.StartFirstWave());
        


        // spawn character
        // init player transform
    }
}
