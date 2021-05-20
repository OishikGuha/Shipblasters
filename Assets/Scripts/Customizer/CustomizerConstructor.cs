using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomizerConstructor : MonoBehaviour
{

    public CustomizerSelector selector;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Construct()
    {
        SceneManager.LoadScene(1);
    }
}
