using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownMachine : MonoBehaviour
{

   public float speed;
    float Startdot = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(transform.position.x, Mathf.PingPong(Startdot,7.0f), transform.position.z);
        Startdot += speed;
    }
}
