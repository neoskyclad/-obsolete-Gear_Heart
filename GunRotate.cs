using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotate : MonoBehaviour
{
    public AudioClip shotSound;
    public GameObject bullet;
    public Transform GunPoint;
    public float shotTime;
    public float ShotDelay;
    public int shots = 3;
    // Start is called before the first frame update
    bool IsShot = true;
    bool shotMode = true;

    float shotTimes;
    float CurrentShotDelay;
    int temp;
    AudioSource audio;
    void Start()
    {
        audio = gameObject.AddComponent<AudioSource>();
        audio.clip = shotSound;
        audio.loop = false;
    }

    void AutoShot(float angle)    //연사
    {   
        if (Input.GetMouseButton(0) && IsShot)
        {
            if (Time.time >= shotTimes)
            {
                Instantiate(bullet, GunPoint.position, Quaternion.AngleAxis(angle - 90, Vector3.forward));
                shotTimes = Time.time + shotTime;
                audio.Play();
            }
        }
    }

    void BurstShot(float angle) //점사
    {
    
        if (Input.GetMouseButton(0) && IsShot)
        {
            if (Time.time >= shotTimes)
            {
                Instantiate(bullet, GunPoint.position, Quaternion.AngleAxis(angle - 90, Vector3.forward));   
                shotTimes = Time.time + shotTime;
                temp--;
                audio.Play();
            }

            if (temp <= 0)
            {
                IsShot = false;
                CurrentShotDelay = ShotDelay;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rotation;

        
        

        if (shotMode)
        {
            AutoShot(angle);
        }
        else
        {
            BurstShot(angle);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (shotMode == true)
            {
                shotMode = false;
                shotTime -= 0.05f;
            }
            else
            {
                shotMode = true;
                shotTime += 0.05f;
            }
        }

        if (IsShot == false)
        {            
            CurrentShotDelay -= Time.deltaTime;

            if (CurrentShotDelay <= 0)
            {
                IsShot = true;
                temp = shots;
            }
        }
        
    }
}
