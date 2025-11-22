using UnityEngine;
using TMPro;

public class CoinDisplay : MonoBehaviour
{
    private TextMeshProUGUI coinText;
    private CoinManager coinManager;

    void Start()
    {
        coinText = GetComponent<TextMeshProUGUI>();

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            coinManager = player.GetComponent<CoinManager>();
        }

        UpdateDisplay();
    }

    void Update()
    {
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        if (coinManager != null && coinText != null)
        {
            coinText.text = "Moedas: " + coinManager.CoinCount.ToString();
        }
    }
}