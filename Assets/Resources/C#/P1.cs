using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1 : MonoBehaviour
{
    public float Speed;
    public Rigidbody rb;
    public float run = 1.5f;

    //角色動作
    public GameObject Idle;
    public GameObject Walk;
    public GameObject Run;
    public GameObject Died;
    public GameObject Sharder;

    //角色位置
    private Vector3 Position;

    //P2角色位置
    public GameObject P2;
    private Vector3 P2Position;
    //空白鍵
    private Collider collider;
    public float passtime = 2.0f;//蓄力時間
    public float releaseWaitTime = 2.0f;//技能持續時間
    private float pressTime = 0f;

    private bool Spacearrow = false;
    private bool iswait = false;

    public GameObject L3;

    //斜坡
    public GameObject GroundWe;

    //彈開力度
    public float bounceForce = 10f;
    private float ABO ;
    public float upwardModifier = 1f;

    //改變透明度
    public float targetAlpha = 0.5f;

    //結算
    public GameObject Die;
    public int X;
    private int A;
    private float Dietime = 0f;
    public float Dietimer = 2.0f;
    public GameObject Fill;

    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0f, 0f, 0f);
        Idle.SetActive(true);
        Walk.SetActive(false);
        Run.SetActive(false);
        Died.SetActive(false);

        ABO = bounceForce;
    }

    // Update is called once per frame
    void Update()
    {

        Idle.SetActive(true);
        Position = gameObject.transform.position;

        if (Input.GetKey(KeyCode.A))
        {
            Idle.GetComponent<SpriteRenderer>().flipX = false;
            Walk.GetComponent<SpriteRenderer>().flipX = false;
            Run.GetComponent<SpriteRenderer>().flipX = false;
            Died.GetComponent<SpriteRenderer>().flipX = false;
            Idle.SetActive(false);
            Walk.SetActive(true);
            gameObject.transform.position += new Vector3(-Speed * Time.deltaTime, 0, 0);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                Walk.SetActive(false);
                Run.SetActive(true);
                gameObject.transform.position += new Vector3(-Speed * Time.deltaTime * run, 0, 0);
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                Run.SetActive(false);
            }
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            Walk.SetActive(false);
            Run.SetActive(false);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Idle.GetComponent<SpriteRenderer>().flipX = true;
            Walk.GetComponent<SpriteRenderer>().flipX = true;
            Run.GetComponent<SpriteRenderer>().flipX = true;
            Died.GetComponent<SpriteRenderer>().flipX = true;
            Idle.SetActive(false);
            Walk.SetActive(true);
            gameObject.transform.position += new Vector3(Speed * Time.deltaTime, 0, 0);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                Walk.SetActive(false);
                Run.SetActive(true);
                gameObject.transform.position += new Vector3(Speed * Time.deltaTime * run, 0, 0);
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                Run.SetActive(false);
            }
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            Walk.SetActive(false);
            Run.SetActive(false);
        }
        //和P2碰撞
        if (P2 != null)
        {
            P2Position = P2.transform.position; // 保存初始位置
            if (transform.position.x < P2Position.x + 0.06f && transform.position.x > P2Position.x - 0.06f && transform.position.y > P2Position.y - 0.01f && transform.position.y < P2Position.y + 0.01f)
            {
                    //角色觸發器打開
                    GetComponent<Collider>().isTrigger = true;
                // 停止物體的重力影響
                rb.isKinematic = true;
                    Spacearrow = true;
                Sharder.SetActive(true);

            }
            else if (Spacearrow == true && GetComponent<Collider>().isTrigger && rb.isKinematic)
            {
                GetComponent<Collider>().isTrigger = false;
                rb.isKinematic = false;
                Spacearrow = false ;
                Sharder.SetActive(false);
            }

        }
        //空白鍵控制
        if (Input.GetKey(KeyCode.Space))
        {
            A = X;
            gameObject.transform.position = Position;
            pressTime += Time.deltaTime;
            if (pressTime >= passtime )
            {
                bounceForce = 0;
                if (Idle != null && Walk != null && Run != null) // 確保 Idle 物件已經被賦值
                {
                    // 獲取 Idle 物件的 Renderer
                    Renderer idleRenderer = Idle.GetComponent<Renderer>();
                    Renderer walkRenderer = Walk.GetComponent<Renderer>();
                    Renderer runRenderer = Run.GetComponent<Renderer>();

                        // 獲取當前顏色
                    Color Color1 = idleRenderer.material.color;
                    Color Color2 = walkRenderer.material.color;
                    Color Color3 = runRenderer.material.color;

                    // 修改透明度 (Alpha 值)
                    Color1.a = targetAlpha;
                    Color2.a = targetAlpha;
                    Color3.a = targetAlpha;

                    // 更新顏色
                    idleRenderer.material.color= Color1;
                    walkRenderer.material.color = Color2;
                    runRenderer.material.color = Color3;
                }
            }
        }
        if (Input.GetKeyUp(KeyCode.Space) && !iswait)
        {
            pressTime = 0;
            iswait = true;
            Time.timeScale = 1f;
            Die.SetActive(false);
            Invoke(nameof(ResetState), releaseWaitTime);
        }
        if (X <= 0)
        {
            Idle.SetActive(false);
            Died.SetActive(true);
            X = 0;
            Dietime += Time.deltaTime;
            Debug.Log(Dietime);
            if (Dietime >= Dietimer)
            {
                Time.timeScale = 0f;
                Die.SetActive(true);
                Fill.SetActive(true);
            }
        }

    }
    private void ResetState()
    {
        if (iswait == true)
        {
            bounceForce = ABO;
            if (Idle != null && Walk != null && Run != null) // 確保 Idle 物件已經被賦值
            {
                // 獲取 Idle 物件的 Renderer
                Renderer idleRenderer = Idle.GetComponent<Renderer>();
                Renderer walkRenderer = Walk.GetComponent<Renderer>();
                Renderer runRenderer = Run.GetComponent<Renderer>();

                // 獲取當前顏色
                Color Color1 = idleRenderer.material.color;
                Color Color2 = walkRenderer.material.color;
                Color Color3 = runRenderer.material.color;

                // 修改透明度 (Alpha 值)
                Color1.a = 1;
                Color2.a = 1;
                Color3.a = 1;

                // 更新顏色
                idleRenderer.material.color = Color1;
                walkRenderer.material.color = Color2;
                runRenderer.material.color = Color3;

}
            X = A;
        }
        iswait = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        // 檢查碰到的物體是否有 Tag "G"
        if (other.CompareTag("Goat"))
        {
            if (iswait)
            {
                X++;
            }
            // 獲取自身的 Rigidbody
            Rigidbody rb = GetComponent<Rigidbody>();
            X -=1;
            if (rb != null)
            {
                // 計算彈開方向 (從碰撞點方向彈開)
                Vector3 bounceDirection = (transform.position - other.transform.position).normalized;
                // 增加向上的分量
                bounceDirection.y += upwardModifier;
                // 確保方向為單位向量
                bounceDirection = bounceDirection.normalized;

                // 添加力到物體
                rb.AddForce(bounceDirection * bounceForce, ForceMode.Impulse);
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        // 檢查碰撞物體的 Tag 是否為 "Ground"
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (Sharder != null)
            {
                Sharder.SetActive(true);
            }

        }
    }
    

        private void OnCollisionExit(Collision collision)
    {
        // 檢查碰撞物體的 Tag 是否為 "Ground"
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (Sharder != null)
            {
                Sharder.SetActive(false);
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("GroundW"))
        {
            if (GroundWe != null)
            {
                GroundWe.SetActive(true);
            }
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("GroundW"))
        {
            if (GroundWe != null)
            {
                GroundWe.SetActive(false);
            }
        }
    }
    void FixedUpdate() // 使用 FixedUpdate 處理物理運算
    {
        // 檢測角色腳下的地面
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.1f)) // 根據角色的高度調整檢測距離
        {
            Vector3 groundNormal = hit.normal; // 獲取地面的法線
            Vector3 slopeDirection = Vector3.Cross(Vector3.Cross(Vector3.up, groundNormal), groundNormal); // 計算沿斜坡方向的移動向量

            if (Input.GetKey(KeyCode.A))
            {
                Vector3 moveDirection = slopeDirection * -Speed * Time.deltaTime;
                rb.MovePosition(transform.position + moveDirection); // 沿斜坡方向移動
                WalkAnimation(false); // 左移動畫
            }

            if (Input.GetKey(KeyCode.D))
            {
                Vector3 moveDirection = slopeDirection * Speed * Time.deltaTime;
                rb.MovePosition(transform.position + moveDirection); // 沿斜坡方向移動
                WalkAnimation(true); // 右移動畫
            }
        }
    }

    // 新增的動畫函式
    void WalkAnimation(bool isRight)
    {
        Idle.SetActive(false);
        Walk.SetActive(true);
        Run.SetActive(Input.GetKey(KeyCode.LeftShift));
        Walk.GetComponent<SpriteRenderer>().flipX = !isRight;
    }




}

