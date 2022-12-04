using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneFromCutscene : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.LoadScene("Level2", LoadSceneMode.Single);
    }
}
