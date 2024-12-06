using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoatS : MonoBehaviour
{
    public GameObject Gaot;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        // 檢查碰到的物體是否有 Tag "G"
        if (other.CompareTag("Ele2"))
        {
            Debug.Log("碰到燈照，死掉");
            Gaot.SetActive(false);
        }
    }
}
