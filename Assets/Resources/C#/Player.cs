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
    private int maxComboCount = 2;
    public float waitTime=2f;
    private int currentComboCount = 0;
    private float timer=0f;

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
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (Time.time - timer > waitTime)
            {
                // 如果超過了等待时間，重置技能
                currentComboCount = 1;
            }
            else
            {
                // 如果在等待时間内，增加連擊數
                currentComboCount = Mathf.Clamp(currentComboCount + 1, 1, maxComboCount);
            }

            // 執行技能
            ExecuteComboSkill(currentComboCount);
            timer = Time.time;
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
    void ExecuteComboSkill(int comboCount)
    {
        // 根据當前連擊數執行不同的技能
        switch (comboCount)
        {
            case 1:
                Debug.Log("第一段技能");
                rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
                P1_animator.SetBool("Jump", true);
                break;
            case 2:
                Debug.Log("第二段技能");
                rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
                P1_animator.SetBool("Jump", true);
                break;
            default:
                break;
        }
    }
}
