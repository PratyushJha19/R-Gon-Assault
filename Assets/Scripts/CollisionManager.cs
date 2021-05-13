using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionManager : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 2f;
    [Tooltip("FX prefab on player")] [SerializeField] GameObject deathVFX;
    [SerializeField] AudioClip deathSound;
    [Tooltip("FX prefab on player")] [SerializeField] ParticleSystem deathFX;//GameObject is the vriable type here. By using it we can add a GameObject to the Script in the UnityEditor
                                                                             // the variable of type "GameObject" (here - deathFX) stores the game object in it, Which is the value of that variable and we provide it in the UnityEditor.
    AudioSource audioSource;

    //Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
        // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        StopControls();
        PlayExplosion();
        Invoke("ReloadScene", levelLoadDelay);
    }

    void StopControls()
    {
        print("Player Dead");
        SendMessage("OnPlayerDeath");//"SendMessage" is Keyword use to call a method of another script attached to that game object 
        //Here "OnPlayerDeath" is a method from another script
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(1);
    }

    void PlayExplosion()
    {
        audioSource.PlayOneShot(deathSound);
        deathFX.Play();
    }

    void ActiveExplosion()
    {
        deathVFX.SetActive(true);
        //SetActive is a keyword used to make a GameObject play. It makes the game object active that means it will make the working.
    }
}

