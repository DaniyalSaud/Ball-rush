using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject particleExplosion;
    private CoinCounter coinText;
    private Player playerObj;
    [SerializeField] private GameObject nextMenu;
    
    void Awake()
    {
        coinText = FindObjectOfType<CoinCounter>();    
        playerObj = FindObjectOfType<Player>();
    }

    private int coinsCnt = 0;
    // We need player reference and we can use FindObject OF type because there is only one player
    public void EndGame()
    {   
        Vector3 explosionPosition = FindObjectOfType<Player>().transform.position; 
        FindObjectOfType<Player>().gameObject.SetActive(false);
        particleExplosion.transform.position = explosionPosition;
        particleExplosion.SetActive(true);
        StartCoroutine(FindObjectOfType<CameraShake>().DeathShake(0.15f, 0.2f));
        Debug.Log("Exploded at : " + explosionPosition);
    }
    public void AddCoin()
    {
        coinsCnt++;
        //UpdateCoinCounter(); call update coins method from CoinCounter class
        coinText.UpdateCoinCount();
    }

    //Create a function to display the number of obtained coins on display
    public int UpdateCoins()
    {
        //Empty function for now
        return coinsCnt;
    }

    public void MagnetPowerUp()
    {
        playerObj.PowerUps[(int)Player.PowerUp.Magnet] = true;
    }

    public void ShieldPowerUp()
    {
        playerObj.PowerUps[(int)Player.PowerUp.Shield] = true;
    }

    public void SpeedPowerUp()
    {
        playerObj.PowerUps[(int)Player.PowerUp.Speed] = true;
    }

    public void WinGame()
    {
        Instantiate(nextMenu);
    }
}
