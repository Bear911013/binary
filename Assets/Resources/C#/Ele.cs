using System.Collections;
using UnityEngine;

public class Ele : MonoBehaviour
{
    public Sprite spriteA; // 初始圖檔 A
    public Sprite spriteB; // 改變後的圖檔 B
    private SpriteRenderer spriteRenderer;
    private bool isCollidingWithPlayer = false;
    private bool hasPressedEnter = false; // 追蹤是否按過 Enter

    public GameObject ele2; // 子物件 Ele2
    private Vector3 ele2OriginalPosition; // Ele2 的初始位置

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = spriteA;

        if (ele2 != null)
        {
            ele2OriginalPosition = ele2.transform.position; // 保存初始位置
        }
    }

    void Update()
    {
        if (isCollidingWithPlayer && Input.GetKeyDown(KeyCode.Return) && !hasPressedEnter)
        {
            spriteRenderer.sprite = spriteB;
            if (ele2 != null)
            {
                ele2.transform.position += new Vector3(0, 2, 0);
            }
            hasPressedEnter = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player2"))
        {
            isCollidingWithPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player2"))
        {
            isCollidingWithPlayer = false;
            StartCoroutine(RestoreStateAfterDelay(2f));
        }
    }

    IEnumerator RestoreStateAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        spriteRenderer.sprite = spriteA;
        hasPressedEnter = false; // 重置按鍵狀態

        if (ele2 != null)
        {
            ele2.transform.position = ele2OriginalPosition; // 恢復到初始位置
        }
    }
}


