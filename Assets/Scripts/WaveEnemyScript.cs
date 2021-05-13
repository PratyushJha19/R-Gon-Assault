using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveEnemyScript : MonoBehaviour
{
    ScoreBoard scoreBoard;
    [SerializeField] int scorePerHit = 12;
    [SerializeField] int hits = 10;
    [SerializeField] GameObject enemyDeathVFX;

    // Start is called before the first frame update
    void Start()
    {
        Collider enemyCollider = gameObject.AddComponent<BoxCollider>();
        enemyCollider.isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnParticleCollision(GameObject other)
    {
        scoreBoard.ScoreHit(scorePerHit);      //'scoreBoard' is a variable name of variable type "ScoreBoard" which is a class of another script and used here to take reference.
        hits = hits - 1;                      //'ScoreHit' is a method in the ScoreBoard script and we have used it here because we want to implement "ScoreHit" method in the "OnParticleCollision" method.
        if (hits < 1)
        {
            enemyDeathVFX.SetActive(true);
            Destroy(gameObject);
        }
    }
}
