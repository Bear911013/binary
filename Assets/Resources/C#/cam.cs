using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{
    public GameObject P1;
    public GameObject P2;
    private Vector3 P1Position;
    private Vector3 P2Position;
    private Vector3 Position;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (P1!= null)
        {
            P1Position = P1.transform.position; // 保存初始位置
        }
        if (P2 != null)
        {
            P2Position = P2.transform.position; // 保存初始位置
        }
        Position = (P1Position + P2Position)/2;
        gameObject.transform.position = new Vector3(Position.x, Position.y, -1.094149f);
    }
}
