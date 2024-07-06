using UnityEngine;
using UnityEngine.Scripting;

public class CameraMovement : MonoBehaviour
{
    // Notes
    // if the level starts, then in the beginning the z coordinate will be near the screen by 5 units, then after getting attached, the z coordinate will be the same as the player's z coordinate.
    // Notes
    /*If the player is attached, the camera must not move but stablize itself according to the axisVector
    */
    public bool startGame;
    [SerializeField] private Player target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float smoothness = 0.125f;
    [SerializeField] private float smoothnessAttached = 0.125f;
    private Vector3 startPosHolder;
    private void Awake(){
        startPosHolder= new Vector3(offset.x, offset.y, offset.z + 5f);
        transform.position = new Vector3(transform.position.x, transform.position.y + 6f, transform.position.z);
        startGame = true;
    }
    private void LateUpdate(){
        if(startGame){
            transform.position = Vector3.Lerp(transform.position, startPosHolder, smoothness * Time.deltaTime);
        }else{
        Vector3 TargetZ;
        if(!target.isAttached){
        // One way is to give the camera offset within the script.
        TargetZ = new Vector3(0f, 0f, target.transform.position.z);
        transform.position = Vector3.Lerp(transform.position, TargetZ + offset, smoothness * Time.deltaTime);
        }else {
            // In the axis, we only want to move it in z-axis, and probably a bit zoom but we will come back to it later.
        TargetZ = new Vector3(0f, 0f, target.AxisVector.z) + offset;
        transform.position = Vector3.Lerp(transform.position, TargetZ, smoothnessAttached * Time.deltaTime);
            }
        }
    }

}
