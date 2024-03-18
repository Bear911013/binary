using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //玩家移動速度
    public float Speed;
    public Rigidbody2D rb;
    public float jumpAmount = 35f;

    [Header("跳躍限制")]
    private int x=0;
    public float waitTime=2f;
    private float timer=0f;
    private bool isWait=false;

    private Animator P1_animator;

    // Start is called before the first frame update
    void Start()
    {
        P1_animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    { //rb.AddForce(x,y),Vector2.up=(0,1),Vector2.down=(0,-1),Vector2.left=(-1,0),
        P1_animator.SetBool("Jump", false);
        P1_animator.SetBool("Jump2", false);
        P1_animator.SetBool("Run", false);
        P1_animator.SetBool("Run2", false);
        P1_animator.SetBool("Walk", false);
        P1_animator.SetBool("Walk2", false);

        if (!isWait&&Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
            P1_animator.SetBool("Jump",true);
            x ++;
            if (x == 2)
            {
                isWait = true;
            }
        }
        if (isWait)
        {
            timer += Time.deltaTime;
            if (timer >= waitTime)
            {
                timer = 0f;
                x = 0;
                isWait = false;
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.position += new Vector3(-Speed * Time.deltaTime, 0, 0);
            
            P1_animator.SetBool("Walk", true);
            if (Input.GetKeyDown(KeyCode.W))
            {
                P1_animator.SetBool("Jump", true);
            }
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                rb.AddForce(Vector2.left * Speed*10, ForceMode2D.Impulse);
                P1_animator.SetBool("Run", true);
            }
 
        }
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.position += new Vector3(Speed* Time.deltaTime, 0, 0);
            
            P1_animator.SetBool("Walk2", true);
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                rb.AddForce(-Vector2.left * Speed*10, ForceMode2D.Impulse);
                P1_animator.SetBool("Run2", true);
            }
 
            if (Input.GetKeyDown(KeyCode.W))
            {
                P1_animator.SetBool("Jump", false);
                P1_animator.SetBool("Jump2", true);
            }
        }
        if (transform.position.x > 14.2f)
        {
            transform.position = new Vector3(14.2f, transform.position.y, 0);
        }

        if (transform.position.x < -30.8f)
        {
            transform.position = new Vector3(-30.8f, transform.position.y, 0);
        }


    }
}
