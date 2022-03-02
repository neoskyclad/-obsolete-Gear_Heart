using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneWait : MonoBehaviour
{
    float lifeTime = 5f;
    public GameObject drone;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(drone.transform.position.x, drone.transform.position.y);
    }
}
