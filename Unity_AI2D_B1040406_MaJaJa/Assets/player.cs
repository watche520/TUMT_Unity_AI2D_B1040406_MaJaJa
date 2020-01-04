using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class player : MonoBehaviour
{
    [Header("移動速度"), Range(0, 1000)]
    public int speed = 50;                  // 整數
    [Header("跳躍高度"), Range(0, 2000)]
    public float jump = 2.5f;               // 浮點數
    private Rigidbody2D r2d;
    private AudioSource aud;
    private CapsuleCollider2D cc2d;
    private Animator ani;
    private bool isGround;
    public UnityEvent onEat;

    public GameObject CAN;

    int HP = 3;
    public GameObject[] HPbar;
    // Start is called before the first frame update
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        cc2d = GetComponent<CapsuleCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)) Turn();
        if (Input.GetKeyDown(KeyCode.A)) Turn(180);
        Jump();
        if (HP == 2)
        {
            Destroy(HPbar[2].gameObject);
        }else
        if (HP == 1)
        {
            Destroy(HPbar[1].gameObject);
        }else
        if (HP <= 0)
        {
            Destroy(HPbar[2].gameObject);
            Destroy(HPbar[1].gameObject);
            Destroy(HPbar[0].gameObject);
            cc2d.isTrigger = true;
            CAN.SetActive(true);
        }
    }
    private void FixedUpdate()
    {
        
        Walk(); // 呼叫方法
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" )
        {
            isGround = true;
            ani.SetBool("jump", false);
        }
        if(collision.gameObject.tag == "MOS")
        {
            HP = HP - 1;
        }
        if (collision.gameObject.tag == "dead")
        {
            HP = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "point")
        {

            Destroy(collision.gameObject);  // 刪除
            onEat.Invoke();                 // 呼叫事件
        }
    }

        private void Walk()
    {
        if (r2d.velocity.magnitude < 10)
            r2d.AddForce(new Vector2(speed * Input.GetAxisRaw("Horizontal"), 0));
        ani.SetBool("run", Input.GetAxisRaw("Horizontal") != 0);
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround == true)
        {
            isGround = false;
            r2d.AddForce(new Vector2(0, jump));
            ani.SetBool("jump", true);
        }
    }
    private void Turn(int direction = 0)
    {
        this.transform.eulerAngles = new Vector3(0, direction, 0);
    }

}
