using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2 : MonoBehaviour
{
    public float Speed;
    public Rigidbody rb;
    public float run = 1.5f;

    //角色動作
    public GameObject Idle;
    public GameObject Walk;
    public GameObject Run;

    public GameObject GroundWe;
    public GameObject Enter;
    public GameObject Ground;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        transform.Rotate(0f, 0f, 0f);
        Idle.SetActive(true);
        Walk.SetActive(false);
        Run.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Idle.GetComponent<SpriteRenderer>().flipX = false;
            Walk.GetComponent<SpriteRenderer>().flipX = false;
            Run.GetComponent<SpriteRenderer>().flipX = false;
            Idle.SetActive(false);
            Walk.SetActive(true);
            gameObject.transform.position += new Vector3(-Speed * Time.deltaTime, 0, 0);
            if (Input.GetKey(KeyCode.RightShift))
            {
                Walk.SetActive(false);
                Run.SetActive(true);
                gameObject.transform.position += new Vector3(-Speed * Time.deltaTime * run, 0, 0);
            }
            if (Input.GetKeyUp(KeyCode.RightShift))
            {
                Run.SetActive(false);
            }

        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            Idle.SetActive(true);
            Walk.SetActive(false);
            Run.SetActive(false);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Idle.GetComponent<SpriteRenderer>().flipX = true;
            Walk.GetComponent<SpriteRenderer>().flipX = true;
            Run.GetComponent<SpriteRenderer>().flipX = true;
            Idle.SetActive(false);
            Walk.SetActive(true);
            gameObject.transform.position += new Vector3(Speed * Time.deltaTime, 0, 0);
            if (Input.GetKey(KeyCode.RightShift))
            {
                Walk.SetActive(false);
                Run.SetActive(true);
                gameObject.transform.position += new Vector3(Speed * Time.deltaTime * run, 0, 0);
            }
            if (Input.GetKeyUp(KeyCode.RightShift))
            {
                Run.SetActive(false);
            }
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            Idle.SetActive(true);
            Walk.SetActive(false);
            Run.SetActive(false);
        }
    }
    private void OnTriggerStay (Collider other)
    {
        // 檢查碰到的物體是否有 Tag "G"
        if (other.CompareTag("Ele"))
        {
            if (Enter != null)
            {
                Enter.SetActive(true);
            }
            if (Input.GetKey(KeyCode.Return))
            {
                Idle.SetActive(false);
                Walk.SetActive(false);
                Run.SetActive(false);
                gameObject.SetActive(false);
            }
            else
            {
                Idle.SetActive(true);
                Walk.SetActive(false);
                Run.SetActive(false);
            }
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ladder"))
        {
            Debug.Log("我碰到梯子了");
            if (GroundWe != null)
            {
                GroundWe.SetActive(true);
            }
        }
    }

        private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ele"))
        {
            Debug.Log("我離開梯子了");
            if (Enter != null)
            {
                Enter.SetActive(false);
            }
            
        }
        if (other.gameObject.CompareTag("ladder"))
        {
            Debug.Log("我離開梯子了");
            if (GroundWe != null)
            {
                GroundWe.SetActive(false);
            }
        }
    }
}
