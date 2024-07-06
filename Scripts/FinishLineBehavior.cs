using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineBehvaior : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Game win!");
        FindObjectOfType<GameManager>().WinGame();
    }
}
