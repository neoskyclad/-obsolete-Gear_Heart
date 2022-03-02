using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecogRange : MonoBehaviour
{
    public bool IsRecog = false;

    void OnTriggerEnter2D(Collider2D collsion)
    {
        if (collsion.gameObject.name == "Character")
        {
            IsRecog = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
