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
        // �ˬd�I�쪺����O�_�� Tag "G"
        if (other.CompareTag("Ele2"))
        {
            Debug.Log("�I��O�ӡA����");
            Gaot.SetActive(false);
        }
    }
}
