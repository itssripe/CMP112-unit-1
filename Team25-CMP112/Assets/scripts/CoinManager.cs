using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public int coinCount;
    public TMP_Text coinText;

    void Update()
    {
        coinText.text = ": " + coinCount.ToString();
    }
}