using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class optionsBack : MonoBehaviour
{
    public void GoBack()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
