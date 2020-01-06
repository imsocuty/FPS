using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour
{
public void ButtonClick()

    {

        SceneManager.LoadScene("FPS");




}

  public  void Regame()

    {


        SceneManager.LoadScene("BG");
        FireCtrl.carryBulletCount += 30;

        gameManager.EndScore();




    }
}
