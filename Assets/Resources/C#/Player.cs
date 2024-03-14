using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //玩家移動速度
    public float Speed;
    public Rigidbody2D rb;
    public float jumpAmount = 35f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { //rb.AddForce(x,y),Vector2.up=(0,1),Vector2.down=(0,-1),Vector2.left=(-1,0),
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.position += new Vector3(-Speed * Time.deltaTime, 0, 0);
        }
            if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.position += new Vector3(Speed* Time.deltaTime, 0, 0);
        }
    }
}
