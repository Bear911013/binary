using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    //���a���ʳt��
    public float Speed;
    public Rigidbody2D rb;
    public float jumpAmount = 35f;

    [Header("���D����")]
    private int x=0;
    public float waitTime=2f;
    private float timer=0f;
    private bool isWait=false;

    private Animator P2_animator;

    // Start is called before the first frame update
    void Start()
    {
        P2_animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    { //rb.AddForce(x,y),Vector2.up=(0,1),Vector2.down=(0,-1),Vector2.left=(-1,0),
        P2_animator.SetBool("Jump", false);
        P2_animator.SetBool("Jump2", false);
        P2_animator.SetBool("Run", false);
        P2_animator.SetBool("Run2", false);
        P2_animator.SetBool("Walk", false);
        P2_animator.SetBool("Walk2", false);

        if (!isWait&&Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
            P2_animator.SetBool("Jump",true);
            x ++;
            if (x == 1)
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
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.transform.position += new Vector3(-Speed * Time.deltaTime, 0, 0);
            
            P2_animator.SetBool("Walk", true);
            if (Input.GetKeyDown(KeyCode.W))
            {
                P2_animator.SetBool("Jump", true);
            }
            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                rb.AddForce(Vector2.left * Speed*10, ForceMode2D.Impulse);
                P2_animator.SetBool("Run", true);
            }
 
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.transform.position += new Vector3(Speed* Time.deltaTime, 0, 0);
            
            P2_animator.SetBool("Walk2", true);
            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                rb.AddForce(-Vector2.left * Speed*10, ForceMode2D.Impulse);
                P2_animator.SetBool("Run2", true);
            }
 
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                P2_animator.SetBool("Jump", false);
                P2_animator.SetBool("Jump2", true);
            }
        }
        if (transform.position.x > 14.2f)
        {
            transform.position = new Vector3(14.2f, transform.position.y, 0);
        }

        if (transform.position.x < -4.8f)
        {
            transform.position = new Vector3(-4.8f, transform.position.y, 0);
        }


    }
}
