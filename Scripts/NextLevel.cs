using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Hide score screen by its name
        GameObject.Find("ScoreScreen").SetActive(false);
        
    }

    public void GotoMainMenu(){
        // Load main menu scene
        SceneManager.LoadScene("MainMenu");
    }
    
}
