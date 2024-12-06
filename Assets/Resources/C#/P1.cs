using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1 : MonoBehaviour
{
    public float Speed;
    public Rigidbody rb;
    public float run = 1.5f;

    //����ʧ@
    public GameObject Idle;
    public GameObject Walk;
    public GameObject Run;
    public GameObject Died;

    //�����m
    private Vector3 Position;

    //P2�����m
    public GameObject P2;
    private Vector3 P2Position;
    //�ť���
    private Collider collider;
    public float passtime = 2.0f;//�W�O�ɶ�
    public float releaseWaitTime = 2.0f;//�ޯ����ɶ�
    private float pressTime = 0f;

    private bool Spacearrow = false;
    private bool iswait = false;

    //�u�}�O��
    public float bounceForce = 10f;
    private float ABO ;
    public float upwardModifier = 1f;

    //���ܳz����
    public float targetAlpha = 0.5f;

    //����
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
        //�MP2�I��
        if (P2 != null)
        {
            P2Position = P2.transform.position; // �O�s��l��m
            if (transform.position.x < P2Position.x + 0.06f && transform.position.x > P2Position.x - 0.06f && transform.position.y > P2Position.y - 0.01f && transform.position.y < P2Position.y + 0.01f)
            {
                    //����Ĳ�o�����}
                    GetComponent<Collider>().isTrigger = true;
                    // ����骺���O�v�T
                    rb.isKinematic = true;
                    Debug.Log("�I��P2�AĲ�o���}�ҡA�����O");
                    Spacearrow = true;

            }
            else if (Spacearrow == true && GetComponent<Collider>().isTrigger && rb.isKinematic)
            {
                Debug.Log("���}P2�A��_���`");
                GetComponent<Collider>().isTrigger = false;
                rb.isKinematic = false;
                Spacearrow = false ;
            }

        }
        //�ť��䱱��
        if (Input.GetKey(KeyCode.Space))
        {
            A = X;
            Debug.Log("�w������");
            gameObject.transform.position = Position;
            pressTime += Time.deltaTime;
            if (pressTime >= passtime )
            {
                Debug.Log("���U�ťը��");
                bounceForce = 0;
                if (Idle != null && Walk != null && Run != null) // �T�O Idle ����w�g�Q���
                {
                    // ��� Idle ���� Renderer
                    Renderer idleRenderer = Idle.GetComponent<Renderer>();
                    Renderer walkRenderer = Walk.GetComponent<Renderer>();
                    Renderer runRenderer = Run.GetComponent<Renderer>();

                        // �����e�C��
                    Color Color1 = idleRenderer.material.color;
                    Color Color2 = walkRenderer.material.color;
                    Color Color3 = runRenderer.material.color;

                    // �ק�z���� (Alpha ��)
                    Color1.a = targetAlpha;
                    Color2.a = targetAlpha;
                    Color3.a = targetAlpha;

                    // ��s�C��
                    idleRenderer.material.color= Color1;
                    walkRenderer.material.color = Color2;
                    runRenderer.material.color = Color3;
                }
            }
        }
        if (Input.GetKeyUp(KeyCode.Space) && !iswait)
        {
            pressTime = 0;
            Debug.Log("��}�ť���");
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
            Debug.Log("���ݨ����_��l���A");
            bounceForce = ABO;
            if (Idle != null && Walk != null && Run != null) // �T�O Idle ����w�g�Q���
            {
                // ��� Idle ���� Renderer
                Renderer idleRenderer = Idle.GetComponent<Renderer>();
                Renderer walkRenderer = Walk.GetComponent<Renderer>();
                Renderer runRenderer = Run.GetComponent<Renderer>();

                // �����e�C��
                Color Color1 = idleRenderer.material.color;
                Color Color2 = walkRenderer.material.color;
                Color Color3 = runRenderer.material.color;

                // �ק�z���� (Alpha ��)
                Color1.a = 1;
                Color2.a = 1;
                Color3.a = 1;

                // ��s�C��
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
        // �ˬd�I�쪺����O�_�� Tag "G"
        if (other.CompareTag("Goat"))
        {
            if (iswait)
            {
                X++;
            }
            // ����ۨ��� Rigidbody
            Rigidbody rb = GetComponent<Rigidbody>();
            X -=1;
            if (rb != null)
            {
                // �p��u�}��V (�q�I���I��V�u�})
                Vector3 bounceDirection = (transform.position - other.transform.position).normalized;
                // �W�[�V�W�����q
                bounceDirection.y += upwardModifier;
                // �T�O��V�����V�q
                bounceDirection = bounceDirection.normalized;

                // �K�[�O�쪫��
                rb.AddForce(bounceDirection * bounceForce, ForceMode.Impulse);
            }
        }
    }
}

