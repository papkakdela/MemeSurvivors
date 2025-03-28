using UnityEngine;

public class RunSettings : MonoBehaviour
{
    [HideInInspector]
    public int characterId = 0;

    public void NextCharacter()
    {
        characterId = characterId + 1;
        if (characterId == L.characters.characters.Length)
            characterId = 0;
        G.ui.UpdateCharacterImage();
    }

}
