using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //���a���ʳt��
    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //����a�첾�W�U���k
        transform.Translate(Input.GetAxis("Horizontal") * Speed, Input.GetAxis("Vertical") * Speed, 0);
    }
}
