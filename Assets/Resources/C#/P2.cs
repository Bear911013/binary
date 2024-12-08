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

    public GameObject Light;

    public GameObject GroundW;
    public GameObject GroundWe;
    public GameObject GroundE;
    // Start is called before the first frame update
    void Start()
    {
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
            Debug.Log("碰到有電物品");
            if (Input.GetKey(KeyCode.Return))
            {
                Idle.SetActive(false);
                Walk.SetActive(false);
                Run.SetActive(false);
                Light.SetActive(true);
                gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("放開Enter");
                Idle.SetActive(true);
                Walk.SetActive(false);
                Run.SetActive(false);
                Light.SetActive(false);
            }
        }
        if (other.gameObject.CompareTag("GroundW"))
        {
            Debug.Log("我碰到斜坡了");
            if (GroundWe != null)
            {
                GroundWe.SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                GroundW.SetActive(true);
                GroundE.SetActive(true);
            }
        }
        if (other.gameObject.CompareTag("GroundE"))
        {
            Debug.Log("我離開斜坡了");
            if (GroundWe != null)
            {
                GroundW.SetActive(false);
                GroundE.SetActive(false);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("GroundW"))
        {
            Debug.Log("我離開斜坡了");
            if (GroundWe != null)
            {
                GroundWe.SetActive(false);
            }
        }
    }
}
