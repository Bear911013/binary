using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Operation : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject W;
    public GameObject A;
    public GameObject S;
    public GameObject D;
    public GameObject Shift;

    //這是遊戲操作
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        W.SetActive(true);
        A.SetActive(true);
        //S.SetActive(true);
        D.SetActive(true);
        Shift.SetActive(true);
        if (Input.GetKey(KeyCode.W))
        {
            W.SetActive(false);
        }
        if (Input.GetKey(KeyCode.A))
        {
            A.SetActive(false);
        }
        /*if (Input.GetKey(KeyCode.S))
        {
            S.SetActive(false);
        }*/
        if (Input.GetKey(KeyCode.D))
        {
            D.SetActive(false);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Shift.SetActive(false);
        }
    }

}
