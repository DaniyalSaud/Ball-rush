using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    public float moveSpeed = 30f;
    [Range(0,1)]public float rotateSpeed = 0.6f;
    public bool isAlive = true;
    public bool isAttached = false;
    bool isMoving = false;
    public Vector3 AxisVector = new Vector3(0f, 0f, 0f);
    private int rotationDirection = 1;

    public bool [] PowerUps;
    
    // Start is called before the first frame update
    public enum PowerUp{
        Magnet,
        Shield,
        Speed
    }
    void Start()
    {
        PowerUps = new bool[3];
        for(int i = 0; i < PowerUps.Length; i++){
            PowerUps[i] = false;
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            isMoving = true;
            isAttached = false;
        }

        if(isAttached){
            //Rotate around the axis
            FindAnyObjectByType<CameraMovement>().startGame = false;
            transform.RotateAround(AxisVector, new Vector3(0f, 1f, 0f), 360 * Time.deltaTime * rotateSpeed * rotationDirection);
        }
        if(isMoving){
            //Move in the forward direction
            transform.position += transform.forward * Time.deltaTime * moveSpeed;
        }
        
        // if a certain powerup is active, setActive the gameObject for that powerup 
        // The rest will be done by the powerup itself, then put the powerup to false
        if(PowerUps[(int)PowerUp.Magnet]){
            // FindAnyObjectByType<Magnet>().gameObject.SetActive(true);

            PowerUps[(int)PowerUp.Magnet] = false;
        }
        if(PowerUps[(int)PowerUp.Shield]){
         //   FindAnyObjectByType<Shield>().gameObject.SetActive(true);
            PowerUps[(int)PowerUp.Shield] = false;
        }
        if(PowerUps[(int)PowerUp.Speed]){
            rotateSpeed += 0.2f;
            moveSpeed += 6f;
            SpeedBehaviorPowerUp sp = FindAnyObjectByType<SpeedBehaviorPowerUp>();
            sp.ran = true;
            PowerUps[(int)PowerUp.Speed] = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {   
        if(other.TryGetComponent(out Wall wall))
        {
            isAlive = false;
            gameManager.EndGame();
            
            Debug.Log("Died!");
        }
        if(other.TryGetComponent(out Rotator rotator)){
                isAttached = true;
                isMoving = false;
                rotationDirection = Random.Range(0,2) * 2 - 1;  // Sets whether to rotate clockwise or anticlockwise
                transform.LookAt(rotator.transform);
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 180f, transform.eulerAngles.z);
                AxisVector = rotator.transform.position;
                float rotationDist = Vector3.Distance(transform.position, AxisVector);
                Debug.Log("Attached!");
                
                // This code is used to make sure the player doesnt clip through the platform
                if(rotationDist < rotator.rotationDistLimit){
                    Debug.Log("Changed Distance");
                    transform.position += transform.forward * (rotator.rotationDistLimit - rotationDist);
                }else if(rotationDist > rotator.rotationDistLimit){
                    Debug.Log("Changed Negative Distance!");
                    transform.position -= transform.forward * Mathf.Abs(rotationDist - rotator.rotationDistLimit);
                }
                Debug.Log(Vector3.Distance(transform.position, AxisVector));
        }
    }

}
