using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadSceneNo1", 5f);
    }
    void LoadSceneNo1()
    {
        SceneManager.LoadScene(1);
        DontDestroyLoad();
    }

    void DontDestroyLoad() { DontDestroyOnLoad(gameObject); }
 // "DontDestroyOnLoad()" is a keyword used for not destroying a game object in the next scene in which it is not used
 // So it preserves the object of the previous scene in the next scene so that it is still applicable and it continues in the next scene.
 // We have used a variable called "gameObject" of type "GameOject", which is already defined in the UnityEngine Package, so we dont need to define it. 
}
