using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomizerConstructor : MonoBehaviour
{

    public CustomizerSelector selector;

    public void Construct()
    {
        SceneManager.LoadScene("Main");
    }
}
