using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField] private string nextLevel;

    public void changeLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }

}
