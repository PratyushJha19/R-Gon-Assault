using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] AudioSource enemyDeathSound;
    ScoreBoard scoreBoard;//Here we have taken reference from the class "ScoreBoard" of "ScoreBoard.cs" script and declared the class name as Variable type with name 'scoreBoard'.
    [SerializeField] int scorePerHit = 12;//value of score per hit
    [SerializeField] int hits = 10;
    [SerializeField] GameObject enemyDeathVFX;

    // Start is called before the first frame update
    void Start()
    {
        NonTriggerCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>(); 
    }
    private void NonTriggerCollider()
    {
        Collider enemyCollider = gameObject.AddComponent<BoxCollider>();
        enemyCollider.isTrigger = false;
        //Here we are saying that Trigger is false/disabled by default in the BoxCollider component above.
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void OnParticleCollision(GameObject other)//It is a method provided by unity engine for collision of particles with the game object
    {
        enemyDeathSound.Play();
        scoreBoard.ScoreHit(scorePerHit);//'ScoreHit' is a method in the ScoreBoard script and we have used it here because we want to implement "ScoreHit" method in the "OnParticleCollision" method.
        //'scoreBoard' is a variable name of variable type "ScoreBoard" which is a class of another script and used here to take reference.
        hits = hits - 1;
        if (hits == 0)
        {
            enemyDeathVFX.SetActive(true);
            Destroy(gameObject);
            enemyDeathSound.Play();
        }
    }
    // { Instantiate(enemyDeathVFX, transform.position, Quaternion.identity); }
    //               ^variable,     ^Position,          ^(Ignored in the course for now)
    // The instantiate keyword commands the game object to work at the position and work as the variable of value the variable Specifeid
    // basically instantiate makes the game object working at runtime.
    //(Syntax for Instantiate is commented because it was not showing effects, alternative used above)
    private void DestroygameObject()
    {
        
    }
}