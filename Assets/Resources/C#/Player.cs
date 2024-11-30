using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    public Rigidbody2D rb;
    public float jumpAmount = 35f;

    [Header("跳躍限制")]
    private int x = 0;
    public float waitTime = 2f;
    private float timer = 0f;
    private bool isWait = false;
    [Header("角色動畫")]
    private Animator P1_animator;

    private bool isCollidingWithBox = false;
    private GameObject currentBox;
    private bool isBoxAttached = false; // 跟踪Box是否被附加到角色

    public float moveDuration = 1.0f; // Box 平滑移动的时间

    public GameObject P2;
    private Operation TimeStop;

    public GameObject End;



    void Start()
    {

        P1_animator = GetComponent<Animator>();

    }

    void Update()
    {
        P1_animator.SetBool("Jump", false);
        P1_animator.SetBool("Jump2", false);
        P1_animator.SetBool("Run", false);
        P1_animator.SetBool("Run2", false);
        P1_animator.SetBool("Walk", false);
        P1_animator.SetBool("Walk2", false);

        transform.Rotate(0f, 0f, 0f);

        if (P2 != null)
        {
            if (transform.position.x > -2.5f)
            {
                Debug.Log("P1到了-2.5");
                P2.SetActive(true);
                P2.transform.position = new Vector3(-2.5f, 5f, 0);

                TimeStop = FindObjectOfType<Operation>();//在操作能找到
                TimeStop.uiCanvas = FindObjectOfType<Canvas>();
                TimeStop.PauseGameTime();

                P2 = null;
            }
        }

        if (!isWait && Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
            P1_animator.SetBool("Jump", true);
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

        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.position += new Vector3(-Speed * Time.deltaTime, 0, 0);
            /*P1_animator.SetBool("Walk", true);
            if (Input.GetKeyDown(KeyCode.W))
            {
                P1_animator.SetBool("Jump", true);
            }*/
        }

        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.position += new Vector3(Speed * Time.deltaTime, 0, 0);
            /*P1_animator.SetBool("Walk2", true);
            if (Input.GetKeyDown(KeyCode.W))
            {
                P1_animator.SetBool("Jump", false);
                P1_animator.SetBool("Jump2", true);
            }*/
        }

        if (transform.position.x > 36f)
        {
            transform.position = new Vector3(36f, transform.position.y, 0);
        }

        if (transform.position.x < -25.5f)
        {
            transform.position = new Vector3(-25.5f, transform.position.y, 0);
        }
        // 檢測空白鍵並移動 Box 或恢復重力
        if (isCollidingWithBox && Input.GetKeyDown(KeyCode.Space))
        {
            if (isBoxAttached)
            {
                // 恢復 Box 物件的重力和運動學屬性
                Rigidbody2D boxRb = currentBox.GetComponent<Rigidbody2D>();
                if (boxRb != null)
                {
                    boxRb.isKinematic = false;
                    boxRb.gravityScale = 1; // 恢復到正常的重力縮放值，視具體情況調整
                }
                // 將 Box 從角色的子物件中移除
                currentBox.transform.SetParent(null);
                isBoxAttached = false;
            }
            else
            {
                Vector3 targetPosition = new Vector3(transform.position.x +0.3f, transform.position.y + 1.3f, transform.position.z);
                if (targetPosition.x> transform.position.x + 1f)
                {
                    targetPosition.x = transform.position.x + 1f;
                }
                if (targetPosition.x < transform.position.x - 1f)
                {
                    targetPosition.x = transform.position.x - 1f;
                }
                if (targetPosition.y > transform.position.y + 2f)
                {
                    targetPosition.y = transform.position.y + 2f;
                }
                if (targetPosition.y < transform.position.y +1.2f)
                {
                    targetPosition.y = transform.position.y+1.2f;
                }

                StartCoroutine(MoveBoxToPosition(currentBox, targetPosition));

                // 禁用 Box 物件的重力和運動學屬性
                Rigidbody2D boxRb = currentBox.GetComponent<Rigidbody2D>();
                if (boxRb != null)
                {
                    boxRb.isKinematic = true;
                    boxRb.gravityScale = 0;
                }

                // 將 Box 設置為角色的子物件
                currentBox.transform.SetParent(transform);
                isBoxAttached = true;

            }
        }
    }

    private IEnumerator MoveBoxToPosition(GameObject box, Vector3 targetPosition)
    {
        Vector3 startPosition = box.transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < moveDuration)
        {
            float t = elapsedTime / moveDuration;
            float smoothStepT = Mathf.SmoothStep(0f, 1f, t);
            box.transform.position = Vector3.Lerp(startPosition, targetPosition, smoothStepT);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        box.transform.position = targetPosition;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Human"))
        {
            HandleHumanCollision(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Goat"))
        {
            Time.timeScale = 0f;
            End.SetActive(true);
        }
    }

    private void HandleHumanCollision(GameObject humanObject)
    {
        Debug.Log("P1碰到了Human物件！");
        Collider2D humanCollider = humanObject.GetComponent<Collider2D>();
        if (humanCollider != null)
        {
            humanCollider.isTrigger = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            Debug.Log("P1持續碰到了Box物件！");
            isCollidingWithBox = true;
            currentBox = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            Debug.Log("P1離開了Box物件！");
            isCollidingWithBox = false;
            currentBox = null;
            Rigidbody2D boxRb = currentBox.GetComponent<Rigidbody2D>();
        }

        if (collision.gameObject.CompareTag("Human"))
        {
            Debug.Log("P1離開了Human物件！");
            ACollision(collision.gameObject);
        }
    }

    private void ACollision(GameObject humanObject)
    {
        Collider2D humanCollider = humanObject.GetComponent<Collider2D>();
        if (humanCollider != null)
        {
            humanCollider.isTrigger = false;
        }
    }
}


