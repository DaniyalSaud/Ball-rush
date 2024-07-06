using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    private static int coinCount;
    public TMP_Text coinText;

    void Awake()
    {
        coinCount = 0;
        coinText.text = coinCount.ToString();
    }

    public void UpdateCoinCount()
    {
        coinCount++;
        coinText.text = coinCount.ToString();
    }

}
