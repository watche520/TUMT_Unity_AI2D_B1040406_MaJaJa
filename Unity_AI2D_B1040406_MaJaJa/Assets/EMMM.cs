using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMMM : MonoBehaviour
{
    public float speed;
    public float a = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        this.transform.position = new Vector3( Mathf.PingPong(a, 13.64f),this.transform.position.y);
        a += speed;

        if(this.transform.position.x >= 13)
        {
            this.gameObject.transform.GetChild(0).transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if(this.transform.position.x  <=1)
        {
            this.gameObject.transform.GetChild(0).transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
}
