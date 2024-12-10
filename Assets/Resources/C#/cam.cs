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
    public GameObject Camra;
    public Vector3 Camra1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Camra1 = Camra.transform.position;
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

        if(Camra.transform.position.x>= -11.33f)
        {
            Camra1.x = -11.34f;
            Camra.transform.position = Camra1;
        }
    }
}
