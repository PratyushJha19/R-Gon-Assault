using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        int numMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;//"FindObjectsOfType<ClassName>().Length" is a keyword which returns the currently active game object to which the script is attached. It should be used with class name to get the return.
        // it is also used as an array as we have used it here with ".Length"
        if (numMusicPlayers > 1)//here we are saying that if the game object works for the 2nd time and more than that then, destroy the Game Object which will work after first time because we dont want it to work more than once 
        {
            Destroy(gameObject);//Destroy is a keyword used make the game object not working or we can say it destroys the game object
        }
        else
        {
            DontDestroyLoad();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DontDestroyLoad() { DontDestroyOnLoad(gameObject); }
    // "DontDestroyOnLoad()" is a keyword used for not destroying a game object in the next scene in which it is not used
    // So it preserves the object of the previous scene in the next scene so that it is still applicable and it continues in the next scene.
    // We have used a variable called "gameObject" of type "GameOject", which is already defined in the UnityEngine Package, so we dont need to define it. 
    //The gameObject variable here will be the Game Object to which the script is attached 
}