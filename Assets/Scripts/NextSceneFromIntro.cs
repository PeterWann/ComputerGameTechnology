using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneFromIntro : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.LoadScene("LogoScene", LoadSceneMode.Single);
    }
}
