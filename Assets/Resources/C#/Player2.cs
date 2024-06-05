using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    //玩家移動速度
    public float Speed;
    public Rigidbody2D rb;
    public float jumpAmount = 35f;

    [Header("跳躍限制")]
    private int x = 0;
    public float waitTime = 2f;
    private float timer = 0f;
    private bool isWait = false;

    private Animator P2_animator;
    private Rigidbody2D boxRb;

    public GameObject End;


    // Start is called before the first frame update
    void Start()
    {
        P2_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        P2_animator.SetBool("Jump", false);
        P2_animator.SetBool("Jump2", false);
        P2_animator.SetBool("Run", false);
        P2_animator.SetBool("Run2", false);
        P2_animator.SetBool("Walk", false);
        P2_animator.SetBool("Walk2", false);

        if (!isWait && Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
            P2_animator.SetBool("Jump", true);
            x++;
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
                rb.AddForce(Vector2.left * Speed * 10, ForceMode2D.Impulse);
                P2_animator.SetBool("Run", true);
            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.transform.position += new Vector3(Speed * Time.deltaTime, 0, 0);

            P2_animator.SetBool("Walk2", true);
            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                rb.AddForce(-Vector2.left * Speed * 10, ForceMode2D.Impulse);
                P2_animator.SetBool("Run2", true);
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                P2_animator.SetBool("Jump", false);
                P2_animator.SetBool("Jump2", true);
            }
        }
        if (transform.position.x > 36f)
        {
            transform.position = new Vector3(36f, transform.position.y, 0);
        }

        if (transform.position.x < -25.8f)
        {
            transform.position = new Vector3(-25.8f, transform.position.y, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Goat"))
        {
            HandleHumanCollision(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Box"))
        {
            HandleBoxCollision(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Human"))
        {
            Time.timeScale = 0f;
            End.SetActive(true);
        }
    }

    private void HandleHumanCollision(GameObject humanObject)
    {
        Debug.Log("P2碰到了Goat物件！");

        Collider2D humanCollider = humanObject.GetComponent<Collider2D>();
        if (humanCollider != null)
        {
            humanCollider.isTrigger = true;
        }
    }

    private void HandleBoxCollision(GameObject boxObject)//物件不會移動(BUG：P2踩在上面會滑動)
    {
        Debug.Log("P2碰到了Box物件！");
        boxRb = boxObject.GetComponent<Rigidbody2D>();
        if (boxRb != null)
        {
            boxRb.isKinematic = true; // 禁用物理效果
            boxRb.constraints = RigidbodyConstraints2D.FreezeAll; // 固定物件的位置和旋轉
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ele"))
        {
            HandleEleCollision(collision.gameObject);
        }
    }
    private void HandleEleCollision(GameObject humanObject)
    {
        Debug.Log("P2碰到了開關物件！");


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Goat"))
        {
            ACollision(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Box"))
        {
            BCollision(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Ele"))
        {
            CCollision(collision.gameObject);
        }
    }

    private void ACollision(GameObject goatObject)
    {
        Debug.Log("P2離開了Goat物件！");

        // 關閉Goat物件的碰撞器
        Collider2D goatCollider = goatObject.GetComponent<Collider2D>();
        if (goatCollider != null)
        {
            goatCollider.isTrigger = false;
        }
    }

    private void BCollision(GameObject boxObject)
    {
        Debug.Log("P2離開了Box物件！");
        if (boxRb != null)
        {
            boxRb.isKinematic = false; // 恢复物理效果
            boxRb.constraints = RigidbodyConstraints2D.None; // 取消固定
            boxRb = null;
        }
    }
    private void CCollision(GameObject boxObject)
    {
        Debug.Log("P2離開開關物件！");
    }
}
