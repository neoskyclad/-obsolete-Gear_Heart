using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text lifeText;
    public Text dashText;
    public int life = 3;    //취약성 보완을 위해 private으로 바꿔 놓을 것

    public void RestartGame()   //게임 재시작 메소드
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GetHit()
    {
        life--;
        lifeText.text = "Life: " + life;
    }

    public void DashCoolOn()
    {
        dashText.text = "대쉬 쿨타임: On";
    }

    public void DashCoolOff()
    {
        dashText.text = "대쉬 쿨타임: Off";
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        if (life == 0)	//만약 목숨이 0이면
        {
            RestartGame();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
    }
}
