using System.Collections;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class Main : MonoBehaviour
{
    GameObject character;

    private void Start()
    {
        // start game
        // spawn hero
        StartCoroutine(StartNewGame());

    }

    IEnumerator StartNewGame() 
    {
        int selectedCharacterId = G.runSettings.characterId;
        character = Instantiate(L.characters.characters[selectedCharacterId], transform.position, Quaternion.identity);
        G.InitPlayer();

        yield return new WaitUntil(() => G.joystick.isControlling);
        G.ui.HideStartRun();

        Coroutine wave = null;
        while (G.playerDamage.IsAlive())
        {
            if (!G.enemySpawner.isWaveInProgress)
                wave = StartCoroutine(G.enemySpawner.StartFirstWave());
            yield return null;
        }


        
        G.ui.ShowGameOver(10);

        // Show game over window

    }
}
