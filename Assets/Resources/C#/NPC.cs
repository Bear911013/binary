using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [Header("����")]
    public GameObject TipObj;
    [Header("���")]
    public GameObject NPCTalk;
    private void OnMouseDown()
    {
        NPCTalk.SetActive(true);
    }

    //���a�I��NPC�A�uĲ�o�{���@��
    private void OnTriggerEnter2D(Collider2D collision)
    {}
    //���a�I��NPC�A�S�����}NPC�A����Ĳ�o�{��
    private void OnTriggerStay2D(Collider2D collision)
    {}
    //���a�I��NPC�A�����}NPC,�uĲ�o�{���@��
    private void OnTriggerExit2D(Collider2D Hit)
    {
        if (Hit.name=="Player")
        {
            TipObj.SetActive(false);
        }
    }
}
