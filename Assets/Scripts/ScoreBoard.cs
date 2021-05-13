using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    int score;// If we dont declare the value of a member variable anywhere in the class, then its value is "0" by default.
    Text scoreText;
    //Text is a variable type and a component provided by the "UnityEngine.UI" package just like AudioSource, Transform, GameObject.
    //It can only be used after using the "UnityEngine.UI" package.

    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();//ToString is a method which makes a non string value to a string value. we have used it here because "ScoreText.text" asks for a String value but "score" is an "int" value.
      //The "ScoreText.text" defines the value of "text" part Under the "Text" component in the UnityEditor.
    }

    public void ScoreHit(int scoreIncrease)
    {
        score = score + scoreIncrease;
        scoreText.text = score.ToString();
     //Here we have declared a new value of score as previous value of score + value of scorePerHit then that will be the new value of score.
    }
}
