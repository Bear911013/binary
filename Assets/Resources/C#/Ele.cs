using System.Collections;
using UnityEngine;

public class Ele : MonoBehaviour
{
    public GameObject P2; // 子物件 Ele2
    private Vector3 P2Position; // Ele2 的初始位置

    public GameObject Light;

    void Start()
    {
        
    }

    void Update()
    {
        P2Position = P2.transform.position;
        if (Input.GetKeyUp(KeyCode.Return))
        {
            P2.SetActive(true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        // 檢查碰到的物體是否有 Tag "G"
        if (other.CompareTag("Player2"))
        {
            if (Input.GetKey(KeyCode.Return))
            {
                P2Position.x = gameObject.transform.position.x;
                P2.transform.position = P2Position;

                Light.SetActive(true);

            }
            else
            {

                Light.SetActive(false);
            }
        }
    }
}


