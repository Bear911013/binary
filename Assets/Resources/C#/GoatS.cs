using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoatS : MonoBehaviour
{
    public float speed = 5f; // ���󲾰ʪ��t��
    private bool shouldMove = true;

    public GameObject End;

    private int x = 1;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            ReloadPage();
        }

        if (shouldMove)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (x == 0)
        {
            Time.timeScale = 0f;
            End.SetActive(true);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("���I��F�p���I");
            x =x- 1;
        }
        if (collision.gameObject.CompareTag("Player2"))
        {
            Debug.Log("���I��F�p�¡I");
            shouldMove = false;
        }
        if (collision.gameObject.CompareTag("Box"))
        {
            Debug.Log("���I��F�c�l�I");
            shouldMove = false;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player2"))
        {
            Debug.Log("�����}�F�p�¡I");
            shouldMove = true;
        }
        if (collision.gameObject.CompareTag("Box"))
        {
            Debug.Log("�����}�F�c�l�I");
            shouldMove = true;
        }
    }

    public void ReloadPage()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName, LoadSceneMode.Single);

    }

}
