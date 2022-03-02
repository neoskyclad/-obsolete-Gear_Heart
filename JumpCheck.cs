using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCheck : MonoBehaviour
{
    GameObject Character;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Bullet")
        {
            Debug.Log("го╢э");
            Character.GetComponent<CharMove>().JumpCount = 1;
            Character.GetComponent<CharMove>().IsJump = false;
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        Character = GameObject.Find("Character");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
