using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBehaviorPowerUp : MonoBehaviour
{
    public bool ran = false;
    void Update()
    {
        if(ran){
            // Start a 4 second couroutine for the power up
            // at the end of this, the speed wil return back to normal
            StartCoroutine(SpeedPowerUp(4f));
            ran = false;
        }
    }

    public IEnumerator SpeedPowerUp(float timer){
        float elapsedTime = 0f;
        Vector3 originalPos = transform.localPosition;

        while (elapsedTime < timer){
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        FindObjectOfType<Player>().rotateSpeed -= 0.2f;
        FindObjectOfType<Player>().moveSpeed -= 6f;
    }
}
