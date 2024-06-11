using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image healthBarFill; 
    public int maxHealth = 100;
    public int currentHealth;
    public Image gameOverUI; 
    public Vector3 respawnPosition; 

    private bool isGameOver = false;

    void Start()
    {
        currentHealth = maxHealth;
        HideGameOverUI(); 
        respawnPosition = transform.position; 
    }

    void Update()
    {
        healthBarFill.fillAmount = (float)currentHealth / maxHealth;

        if (isGameOver && Input.anyKeyDown)
        {
            RespawnPlayer(); 
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player died.");
        ShowGameOverUI(); 
        isGameOver = true;
    }

    private void RespawnPlayer()
    {
        transform.position = respawnPosition; 
        currentHealth = maxHealth; 
        HideGameOverUI(); 
        isGameOver = false; 
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
