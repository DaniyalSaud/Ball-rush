using System;
using System.Collections;
using System.Threading;
using UnityEngine;

public class SpikesBehavior : MonoBehaviour
{
    private Vector3 finalPosition;
    private Vector3 initPosition;
    private bool atTop = false;
    private bool inMotion = false;
    private bool TopStop = false;
    private bool BottomStop = true;
    [SerializeField] [Range(0.1f, 2f)] private float TimerUp;
    [SerializeField] [Range(0.1f, 2f)] private float TimerDown;
    [SerializeField] [Range(0.1f, 2f)] private float TimerStop;


    // Start is called before the first frame update
    void Start()
    {
        // get the initial position
        initPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        // get the final position
        finalPosition = new Vector3(transform.localPosition.x, initPosition.y + 1f, transform.localPosition.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(!atTop && !inMotion && BottomStop){
            // move them upwards to final position using lerp
            // Use a coroutine
            // when they reach the top, set atTop to true
            StartCoroutine(moveUp(TimerUp));
            inMotion = true;
        }else if(atTop && !inMotion && !TopStop){
            // if they are at the top, stop them for 1 second
            StartCoroutine(TopBreak(TimerStop));
            inMotion = true;
        }else if(atTop && !inMotion && TopStop){
            // if they are at the top, move them back to the initial position, immediately retract in 0.5 seconds
            // Start a coroutine to do this, when the coroutine ends, set atTop to false
            StartCoroutine(moveDown(TimerDown));
            inMotion = true;
        }else if(!atTop && !inMotion && !BottomStop){
            // if they are at the bottom, stop them for 1 second
            // Start a coroutine to do this, when the coroutine ends, set midStop to true
            // StartCoroutine(moveUp(1f));
            StartCoroutine(BottomBreak(TimerStop)); 
            inMotion = true;      
        }
    }
     public IEnumerator moveUp(float timerUp){
        float elapsedTime = 0f;
        Vector3 originalPos = transform.localPosition;

        while (elapsedTime < timerUp){
            // Here we will lerp the original position to final position
            transform.localPosition = Vector3.Lerp(originalPos, finalPosition, (elapsedTime/timerUp));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = finalPosition;
        inMotion = false;
        atTop = true;
        BottomStop = false;

    }
     public IEnumerator moveDown(float timerDown){
        float elapsedTime = 0f;
        Vector3 originalPos = transform.localPosition;

        while (elapsedTime < timerDown){
            // Here we will lerp the original position to final position
            transform.localPosition = Vector3.Lerp(originalPos, initPosition, (elapsedTime/timerDown) * 12f);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = initPosition;
        inMotion = false;
        TopStop = false;
        atTop = false;
    }

    private IEnumerator TopBreak(float time){
        float elapsedTime = 0f;
        while (elapsedTime < time){
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        TopStop = true;
        inMotion = false;
    }

    private IEnumerator BottomBreak(float time){
        float elapsedTime = 0f;
        while (elapsedTime < time){
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        BottomStop = true;   
        inMotion = false;
    }

}
