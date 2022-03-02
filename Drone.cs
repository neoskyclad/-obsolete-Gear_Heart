using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : Mob
{

    bool IsRecog;
    bool IsAnim = true;

    public GameObject RecogRange;

    public GameObject DroneWait;
    GameObject target;

    public float moveSpeed;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 direction = transform.position - collision.transform.position;
        direction = direction.normalized * 1000;
        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(direction);
        GameObject.Find("GameManager").SendMessage("GetHit");
    }
    
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Character");
    }

    // Update is called once per frame
    void Update()
    {
        if (RecogRange.GetComponent<RecogRange>().IsRecog)  //만약 인식범위 안에 들어오면
        {
            if (IsAnim)
            {
                Instantiate(DroneWait, transform.position, Quaternion.identity);
                IsAnim = false;
            }
            
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed);

        }
    }
}
