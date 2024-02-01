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
    {
        //控制玩家位移上下左右
        transform.Translate(Input.GetAxis("Horizontal") * Speed, Input.GetAxis("Vertical") * Speed, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //rb.AddForce(x,y),Vector2.up=(0,1),Vector2.down=(0,-1),Vector2.left=(-1,0),
            rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
        }
    }
}
