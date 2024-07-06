using UnityEngine;

public class Gems : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") { 
            FindObjectOfType<GameManager>().AddCoin();
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

}
