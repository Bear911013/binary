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
        Debug.Log("P2�I��FGoat����I");

        Collider2D humanCollider = humanObject.GetComponent<Collider2D>();
        if (humanCollider != null)
        {
            humanCollider.isTrigger = true;
        }
    }

    private void HandleBoxCollision(GameObject boxObject)//���󤣷|����(BUG�GP2��b�W���|�ư�)
    {
        Debug.Log("P2�I��FBox����I");
        boxRb = boxObject.GetComponent<Rigidbody2D>();
        if (boxRb != null)
        {
            boxRb.isKinematic = true; // �T�Ϊ��z�ĪG
            boxRb.constraints = RigidbodyConstraints2D.FreezeAll; // �T�w���󪺦�m�M����
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
        Debug.Log("P2�I��F�}������I");


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
        Debug.Log("P2���}�FGoat����I");

        // ����Goat���󪺸I����
        Collider2D goatCollider = goatObject.GetComponent<Collider2D>();
        if (goatCollider != null)
        {
            goatCollider.isTrigger = false;
        }
    }

    private void BCollision(GameObject boxObject)
    {
        Debug.Log("P2���}�FBox����I");
        if (boxRb != null)
        {
            boxRb.isKinematic = false; // ���`���z�ĪG
            boxRb.constraints = RigidbodyConstraints2D.None; // �����T�w
            boxRb = null;
        }
    }
    private void CCollision(GameObject boxObject)
    {
        Debug.Log("P2���}�}������I");
    }
}
