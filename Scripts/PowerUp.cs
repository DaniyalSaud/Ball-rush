using UnityEngine;

public class PowerUp : MonoBehaviour
{
    string powerUpType;
    [SerializeField] private float rotateSpeed = 50f;
     private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") { 
            if(powerUpType == "Magnet"){
                FindObjectOfType<GameManager>().MagnetPowerUp();
            }else if(powerUpType == "Shield"){
                FindObjectOfType<GameManager>().ShieldPowerUp();
            }else if(powerUpType == "Speed"){
                FindObjectOfType<GameManager>().SpeedPowerUp();
            }
            
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    private void Start(){
        powerUpType = gameObject.tag;
    }
    void rotate(){
        transform.Rotate(0f, rotateSpeed * Time.deltaTime, 0f);
    }

    void Update(){
        rotate();
    }

}