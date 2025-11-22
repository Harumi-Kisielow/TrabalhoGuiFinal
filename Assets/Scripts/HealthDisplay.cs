using UnityEngine;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
    private TextMeshProUGUI healthText;
    private PlayerStats playerStats;

    void Start()
    {
        healthText = GetComponent<TextMeshProUGUI>();

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerStats = player.GetComponent<PlayerStats>();
        }

        UpdateDisplay();
    }

    void Update()
    {
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        if (playerStats != null && healthText != null)
        {
            healthText.text = "Vidas: " + playerStats.CurrentHealth.ToString();
        }
    }
}