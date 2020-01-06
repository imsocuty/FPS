using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    
    Vector3 pos; //현재위치

    float delta = 4.0f; // 좌(우)로 이동가능한 (x)최대값

    
    float speed = 4.0f; // 이동속도
    public int HP;
    public GameObject explosion;
    private Enemy_Data enemyData;
    public GameObject healthBarBackground;
    public Image healthBarFilled;
    // static public int killScore = 100;


    void Start()
    {
        enemyData = new Enemy_Data(HP);
        Debug.Log(gameObject.name + "의 체력 : " + enemyData.getHP());
        pos = transform.position;
       
        healthBarFilled.fillAmount = 1f;

        
    }

    void Update()
    {

       Vector3 v = pos;

        v.x += delta * Mathf.Sin(Time.time * speed);
       
        transform.position = v;

        if (enemyData.getHP() <= 0)
        {   
            
             SoundManager.instance.PlaySound();
            Debug.Log("파괴!!!!!");
            Destroy(gameObject);



            //int carryBulletCount = FireCtrl.carryBulletCount;
            //carryBulletCount = carryBulletCount + 20;
            FireCtrl.carryBulletCount += 10;
            // 현재 적의 오브젝트를 메모리풀링으로 만들지 않았기 때문에
            // Destroy로 처리합니다.
            Instantiate(explosion, transform.position, transform.rotation);

            int Score = gameManager.getScore();
            Debug.Log(Score);
            Score += 100;

            gameManager.instance.AddScore(Score);

            

        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        // 부딛히는 collision을 가진 객체의 태그가 "Player Missile"일 경우
        if (collision.CompareTag("BULLET"))
        {
            
            Debug.Log("미사일과 충돌");
            enemyData.decreaseHP(10);   // 체력을 10 감소
            Debug.Log(gameObject.name + "의 현재 체력 : " + enemyData.getHP());
           
        }

        healthBarFilled.fillAmount = (float)enemyData.getHP() / HP;
      
    }

    
   
}


