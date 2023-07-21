using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Fox : MonoBehaviour
{
    public TMP_Text healthText;
    public float curHealth;
    public GameManager gameManager;

    public void TakeDamage(int damageAmount)
    {
        curHealth -= damageAmount;

        if (curHealth <= 0)
        {
            Die();
        }

        UpdateHealthBarText();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Win"))
        {
            Debug.Log("Winner");
            gameManager.winScreen.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void Die()
    {
        // Implement what should happen when the player dies (e.g., game over or respawn).
        gameManager.gameOver.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        // For demonstration purposes, you can destroy the player GameObject or disable player controls here.
    }

    void UpdateHealthBarText()
    {
        // Update the Health Bar Text to represent the current health.
        if (healthText != null)
        {
            healthText.text = "Health: " + curHealth.ToString();
        }
    }
}
