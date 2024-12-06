using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2 : MonoBehaviour
{
    public float Speed;
    public Rigidbody rb;
    public float run = 1.5f;

    //����ʧ@
    public GameObject Idle;
    public GameObject Walk;
    public GameObject Run;

    public GameObject Light;
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
        // �ˬd�I�쪺����O�_�� Tag "G"
        if (other.CompareTag("Ele"))
        {
            Debug.Log("�I�즳�q���~");
            if (Input.GetKey(KeyCode.Return))
            {
                Idle.SetActive(false);
                Walk.SetActive(false);
                Run.SetActive(false);
                Light.SetActive(true);
            }
            else
            {
                Debug.Log("��}Enter");
                Idle.SetActive(true);
                Walk.SetActive(false);
                Run.SetActive(false);
                Light.SetActive(false);
            }
        }
    }
}
