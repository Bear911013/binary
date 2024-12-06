using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ele2 : MonoBehaviour
{
    public GameObject Goat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Goat"))
        {
            Debug.Log("¸I¨ì°­¤F¡A±þ±¼");
            Goat.SetActive(false);
        }
    }
}
