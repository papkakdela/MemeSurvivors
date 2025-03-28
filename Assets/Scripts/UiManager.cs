using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [Header("Main Menu")]
    [SerializeField] GameObject mainMenuWindow;
    [SerializeField] Image characterImage;

    [Header("Start Run")]
    [SerializeField] GameObject startRunText;

    [Header("Game Over Menu")]
    [SerializeField] GameObject gameOverWindow;
    [SerializeField] TMP_Text gameOverResultText;


    public void ShowStartRun()
    {
        startRunText.SetActive(true);
    }

    public void HideStartRun()
    {
        startRunText.SetActive(false);
    }

    public void ShowMainMenuWindow()
    {
        mainMenuWindow.SetActive(true);
    }

    public void HideMainMenuWindow()
    {
        mainMenuWindow.SetActive(false);
    }


    public void ShowGameOver(int result)
    {
        gameOverResultText.text = result.ToString();
        gameOverWindow.SetActive(true);
    }

    public void HideGameOver()
    {
        gameOverWindow.SetActive(false);
    }

    public void UpdateCharacterImage()
    {
        // TBD
        // Character image.sprite = L.characters.characters[G.runSettings.charaacterId.GetComponent<SpriteRenderer>().image;
    }

    public void ClickContinueButton()
    {
        // Destroy enemies
        G.playerDamage.RestoreHealth();
        HideGameOver();
    }

    public void ClickRestartButton()
    {
        HideGameOver();
    }
}
