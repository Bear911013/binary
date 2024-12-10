using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Latter : MonoBehaviour
{
    public GameObject Light;
    bool L;
    public Vector3 LightP;
    public GameObject P2;
    float A = 0.07f;
    public GameObject P2up;
    // Start is called before the first frame update
    void Start()
    {
        LightP = Light.transform.position;
    }

    // Update is called once per frame
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player2"))
        {
            L = true;
        }
    }

    private void Update()
    {
        if (L == true && Input.GetKey(KeyCode.UpArrow))
        {
            Light.SetActive(true);
            P2.SetActive(false);
            P2.transform.position += new Vector3(0, A * Time.deltaTime, 0);
            Light.transform.position += new Vector3(0, A * Time.deltaTime, 0);
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            P2.SetActive(true);
            Light.transform.position = LightP;
            Light.SetActive(false);
            L = false;
            P2up.SetActive(false);
        }

    }
}
