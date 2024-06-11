using UnityEngine;
using UnityEngine.UI;

public class RespawnManager : MonoBehaviour
{
    public GameObject player; 
    public Vector3 respawnPosition; 
    public Image gameOverUI; 

    private bool isGameOver = false;

    void Start()
    {
        respawnPosition = player.transform.position; 
        HideGameOverUI(); 
    }

    void Update()
    {
        if (isGameOver && Input.anyKeyDown)
        {
            RespawnPlayer(); 
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        ShowGameOverUI(); 
    }

    private void RespawnPlayer()
    {
        player.transform.position = respawnPosition; 
        player.GetComponent<PlayerHealth>().currentHealth = player.GetComponent<PlayerHealth>().maxHealth; 
        isGameOver = false; 
        HideGameOverUI(); 
    }

    private void ShowGameOverUI()
    {
        if (gameOverUI != null)
        {
            gameOverUI.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError("gameOverUI is not assigned!");
        }
    }

    private void HideGameOverUI()
    {
        if (gameOverUI != null)
        {
            gameOverUI.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("gameOverUI is not assigned!");
        }
    }
}
