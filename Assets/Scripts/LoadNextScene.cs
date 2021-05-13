using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    void Update()
    {
        OnUserInput();
    }
    void LoadSceneNo1()
    {
        SceneManager.LoadScene(1);
    }

    void OnUserInput()
    {
        if (Input.GetKey(KeyCode.Space))
            LoadSceneNo1();
    }
}
