using System.Collections;
using UnityEngine;

public class Ele : MonoBehaviour
{
    public GameObject P2; // �l���� Ele2
    private Vector3 P2Position; // Ele2 ����l��m

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
        // �ˬd�I�쪺����O�_�� Tag "G"
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


