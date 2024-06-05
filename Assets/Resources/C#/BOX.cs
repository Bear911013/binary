using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOX : MonoBehaviour
{
    public GameObject Box01; // 子物件 Ele2
    private Vector3 ele2OriginalPosition; // Ele2 的初始位置
    // Start is called before the first frame update
    void Start()
    {
        if (Box01 != null)
        {
            ele2OriginalPosition = Box01.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            Debug.Log("得到箱子了");
            Box01.transform.position = new Vector3(Box01.transform.position.x, Box01.transform.position.y+5, 0);

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            Debug.Log("離開箱子了");
            Box01.transform.position = ele2OriginalPosition;

        }
    }
}
