using UnityEngine;
using System.Collections;
using UnityEngine.UI; //Text를 쓰실거면 추가해주세요
public class gameManager : MonoBehaviour
{
    public Text scoreText;
    GameObject player;
    static private int score = 0;
    public static gameManager instance;
    void Awake()
    {
        if (gameManager.instance == null)//게임이 시작하면 실행되는 함수
            gameManager.instance = this;
       


    }
    void Start()
    {
        player = GameObject.FindWithTag("Player"); //플레이어 태그를 찾는다.
        //StartGame();
        Invoke("StartGame", 3f);
    }

    static public void setScore(int n)
    {
        score = n;
    }

    static public int getScore()
    {
        return score;
    }


    public void AddScore(int n)
    {
        score += n;
        //print(score);
        scoreText.text = "Score:" + score; //스코어에 올립니다.
    }

    static public void EndScore()
    {

        score = 0;
       
    }
}

 


