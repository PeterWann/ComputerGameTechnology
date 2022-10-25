using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        LevelChanger.Instance.FadeToNextLevel();
    }
}
