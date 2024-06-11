using UnityEngine;
using UnityEngine.UI;

public class Princess : MonoBehaviour
{
    public Image winImage; 
    private bool isGameWon = false;

    void Start()
    {
        HideWinImage(); 
    }

    void Update()
    {
        if (isGameWon && Input.anyKeyDown)
        {
            QuitGame(); 
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ShowWinImage(); 
            isGameWon = true; 
        }
    }

    private void ShowWinImage()
    {
        if (winImage != null)
        {
            winImage.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            Debug.LogError("winImage is not assigned!");
        }
    }

    private void HideWinImage()
    {
        if (winImage != null)
        {
            winImage.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("winImage is not assigned!");
        }
    }

    private void QuitGame()
    {
        Debug.Log("Game is quitting...");
        Application.Quit(); 
    }
}
