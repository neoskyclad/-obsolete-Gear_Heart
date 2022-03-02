using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bullet;
    float timeCount = 0;

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
 
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = GameObject.Find("Character").transform.position - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        timeCount += Time.deltaTime;
        if (timeCount > 2)
        {
            Instantiate(bullet, transform.position, Quaternion.AngleAxis(angle - 90, Vector3.forward));

            timeCount = 0;
        }
    }
}
