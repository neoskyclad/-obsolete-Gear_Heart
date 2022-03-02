using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject Character;
    Transform CharPosition;
    float MovingSpeed = 0;
    public float PosY;
    public float PosX;
    public float speed = 0.001f;

    float RightMiddle;
    float LeftMiddle;
    // Start is called before the first frame update
    void Awake()
    {
        CharPosition = Character.transform;
        transform.position = new Vector3(CharPosition.position.x + PosX, PosY, transform.position.z);    //�⺻ ī�޶� ��ġ

        RightMiddle = Screen.width / 4;
        LeftMiddle =  - (Screen.width / 4);
    }

    // Update is called once per frame
    void Update()
    {
        if (Screen.width / 2 + RightMiddle < Input.mousePosition.x) //Left
        {
            transform.position = new Vector3(transform.position.x + MovingSpeed, PosY, transform.position.z);
            MovingSpeed += speed;

            if (transform.position.x >= CharPosition.position.x + PosX)
            {
                transform.position = new Vector3(CharPosition.position.x + PosX, PosY, transform.position.z);    //ī�޶� ������ �̵�
                MovingSpeed = 0;
            }        
        }
        else if (Screen.width / 2 + LeftMiddle > Input.mousePosition.x) //Right
        {
            transform.position = new Vector3(transform.position.x - MovingSpeed, PosY, transform.position.z);
            MovingSpeed += speed;

            if (transform.position.x <= CharPosition.position.x - PosX)
            {
                transform.position = new Vector3(CharPosition.position.x - PosX, PosY, transform.position.z);    //ī�޶� ���� �̵�
                MovingSpeed = 0;
            }       
        }
        else //Middle
        {
            MovingSpeed = 0;
            transform.position = new Vector3(transform.position.x, PosY, transform.position.z);            
        }
    }           
}
