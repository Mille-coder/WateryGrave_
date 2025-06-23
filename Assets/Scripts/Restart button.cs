using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restartbutton : MonoBehaviour
{


    public void Restarted()
    {
        Debug.Log("Click");
        SceneManager.LoadSceneAsync(0);
    }
}
