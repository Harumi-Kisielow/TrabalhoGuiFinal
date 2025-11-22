using UnityEngine;

public class CoinManager : MonoBehaviour
{
    private int coinCount = 0;

    public int CoinCount
    {
        get { return coinCount; }
        private set { coinCount = value; }
    }

    public void AddCoin()
    {
        CoinCount += 1;
        Debug.Log("Moeda Coletada: " + CoinCount);
    }
}