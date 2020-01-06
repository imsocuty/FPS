using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class FireCtrl : MonoBehaviour
{

    public GameObject bullet;
    public Transform firePos;

    public int reloadBulletCount; // 총알 재장전 개수
    public int currentBulletCount; // 현재 탄창에 남아있는 총알 개수
    public int maxBulletCount; // 최대 소유 가능한 총알 개수
   static public int carryBulletCount=30; // 현재 소유하고 있는 총알 개수
    public ParticleSystem explosion1;



    public float FireDelay;
    private bool FireState;
    private bool ReloadState;
 
    public float mouse_speedX = 3.0f;    //마우스 좌우
    public float mouse_speedY = 3.0f;    //마우스 상하
    float rotationY = 0f;

     public AudioSource _audio;
     public AudioClip[] _clipList;
      

    [SerializeField]
    private Text[] text_Bullet;

   

  
    void Start()
    {

        FireState = true;
        ReloadState = true;
    
}

   
 void LateUpdate () {
 
        float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * mouse_speedX;      // 마우스 좌우 회전 시키는 이벤트
 
        //마우스 상하 움직이기
        rotationY -= Input.GetAxis("Mouse Y") * mouse_speedY;    // +=로 하면 마우스 반전 상하로 바뀌게됨
        rotationY = Mathf.Clamp(rotationY, -20.0f, 60.0f);       //상하 범위 제한 시키기, 왜냐하면 위로 향하는데 360도로 돌기때문.
 
        transform.localEulerAngles = new Vector3(rotationY, rotationX, 0);
    }

    void Update()
    {   
        if (FireState)
        {

        
        if (currentBulletCount > 0) { 
        
                Fire();


        if(carryBulletCount < 1 && currentBulletCount < 1){

            SceneManager.LoadScene("OVER");

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }    

            }

       
       
   
}
  
        TryReload();
        CheckBullet();

   }


    private void TryReload()
    { 
       
            if (Input.GetKeyDown(KeyCode.R) && currentBulletCount < reloadBulletCount )
            {
            _audio.clip = _clipList[0];
            _audio.Play();

            StartCoroutine(ReloadCycleControl());

         
        }


    }

 
private void Reload()
    {


        if(carryBulletCount >0)
        {

            
            carryBulletCount += currentBulletCount;
            currentBulletCount = 0;

            if (carryBulletCount >= reloadBulletCount)
            {
                
                currentBulletCount = reloadBulletCount;
                carryBulletCount -= reloadBulletCount;
            }

            else
            {
                currentBulletCount = carryBulletCount;
                carryBulletCount = 0;

            }

       
        }
    }
    

 void Fire ()
    {

        if (Input.GetMouseButton(0) && ReloadState == true)
        {

            _audio.clip = _clipList[1];
            _audio.Play();
           

            explosion1.Play();
            
            StartCoroutine(FireCycleControl());
            
            CreateBullet();


            if (currentBulletCount < 1)
            {

                _audio.clip = _clipList[2];
                _audio.Play();

            }
        }
        
    }



   IEnumerator FireCycleControl()
    {

        
        FireState = false;
        
        yield return new WaitForSeconds(FireDelay);
        FireState = true;
       
    }

     IEnumerator ReloadCycleControl()
    {

        
        ReloadState = false;
        
        yield return new WaitForSeconds(2);

        ReloadState = true;

        Reload();
    }


 

    public void CreateBullet() {

        Instantiate(bullet, firePos.position, firePos.rotation);

       
        currentBulletCount--;
        
    }

    

    public void CheckBullet()
    {

  

        text_Bullet[0].text = carryBulletCount.ToString();
        text_Bullet[1].text = reloadBulletCount.ToString();
        text_Bullet[2].text = currentBulletCount.ToString();

    }
    

}

   
