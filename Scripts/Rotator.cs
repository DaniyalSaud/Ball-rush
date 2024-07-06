using UnityEngine;

public class Rotator : MonoBehaviour
{   public string privName = "Rotor";
    public float rotationSpeed = 2f;
    public float rotationDistLimit;

    [SerializeField] private bool rotateReverse = false;
    private void Awake()
    {
   

    //Clean and good code, this way, i wont have to worry about scaling the platforms and coming here to change their rotationDistanceLimits
    rotationDistLimit = (5.7f / 3.8f) * transform.localScale.x;
    if(rotationDistLimit > 1.8f){
        rotationDistLimit = (5.3f / 3.8f) * transform.localScale.x;
    }
    if(rotationDistLimit > 2.5f){
        rotationDistLimit = (5.1f / 3.8f) * transform.localScale.x;

    }
    }
    private void FixedUpdate(){
        if(rotateReverse){
            Vector3 angles = new Vector3(0f,-1f,0f);
            transform.eulerAngles += angles * Time.deltaTime * rotationSpeed;
            }else{
        Vector3 angles = new Vector3(0f,1f,0f);
        transform.eulerAngles += angles * Time.deltaTime * rotationSpeed;
        }
    }
}