using System.Collections;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class Main : MonoBehaviour
{
    private void Start()
    {
        // start game
        // spawn hero
    }

    IEnumerator StartNewGame() 
    {
        int selectedCharacterId = G.runSettings.characterId;
        var character = Instantiate(L.characters.characters[selectedCharacterId]);
        G.InitPlayer();

        yield return new WaitUntil(() => G.joystick.isControlling);
        G.ui.HideStartRunWindow();


        var wave = StartCoroutine(G.enemySpawner.StartFirstWave());
        


        // spawn character
        // init player transform
    }
}
