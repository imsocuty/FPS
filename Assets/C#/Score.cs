using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public Text scoreText;

    void Start()
    {

        int Score = gameManager.getScore();
        Debug.Log(Score);
        scoreText.text = "Score:" + Score;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
