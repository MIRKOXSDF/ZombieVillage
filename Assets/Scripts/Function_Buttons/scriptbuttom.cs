using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptbuttom : MonoBehaviour
{
    public void Change(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
