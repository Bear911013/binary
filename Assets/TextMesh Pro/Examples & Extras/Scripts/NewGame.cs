using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGame : MonoBehaviour
{
    public GameObject P1;
    public GameObject P2;
    public float P1Run=0.105f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        P1.transform.position += new Vector3(0.105f *Time.deltaTime, 0, 0);
    }
}
