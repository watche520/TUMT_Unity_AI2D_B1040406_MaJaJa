using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOX : MonoBehaviour
{
    public GameObject point;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Instantiate(point, new Vector3(this.transform.position.x, this.transform.position.y + 2, this.point.transform.position.z),this.transform.rotation).SetActive(true);
            Destroy(this.gameObject);

        }
    }
}
