using System.Collections;
using UnityEngine;

public class Ele : MonoBehaviour
{
    public Sprite spriteA; // ��l���� A
    public Sprite spriteB; // ���ܫ᪺���� B
    private SpriteRenderer spriteRenderer;
    private bool isCollidingWithPlayer = false;
    private bool hasPressedEnter = false; // �l�ܬO�_���L Enter

    public GameObject ele2; // �l���� Ele2
    private Vector3 ele2OriginalPosition; // Ele2 ����l��m

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = spriteA;

        if (ele2 != null)
        {
            ele2OriginalPosition = ele2.transform.position; // �O�s��l��m
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
        hasPressedEnter = false; // ���m���䪬�A

        if (ele2 != null)
        {
            ele2.transform.position = ele2OriginalPosition; // ��_���l��m
        }
    }
}


