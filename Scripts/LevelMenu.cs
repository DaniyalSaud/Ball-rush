using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    public void openlevel(int levelID)

    {
        string levelname = "Level" + levelID;
        SceneManager.LoadScene(levelname);

    }
}
