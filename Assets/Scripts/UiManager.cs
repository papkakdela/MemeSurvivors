using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverWindow;
    [SerializeField] TMP_Text gameOverResultText;


    public void ShowGameOver(int result)
    {
        gameOverResultText.text = result.ToString();
        gameOverWindow.SetActive(true);
    }

    public void HideGameOver()
    {
        gameOverWindow.SetActive(false);
    }
}
