using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public IEnumerator DeathShake(float timeDuration, float magnitude){
        float elapsedTime = 0f;
        Debug.Log("Shook!");
        Vector3 originalPos = transform.localPosition;

        while (elapsedTime < timeDuration){
            float x = Random.Range(-1,1) * magnitude;
            float y = Random.Range(-1,1) * magnitude;
            float z = Random.Range(-1,1) * magnitude;

            transform.localPosition = new Vector3(x, y, z);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = originalPos;
    }
}
