using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CoinManager coinManager = other.GetComponent<CoinManager>();

            if (coinManager != null)
            {
                coinManager.AddCoin();

                Collect();
            }
        }
    }

    private void Collect()
    {
        Destroy(gameObject);
    }
}