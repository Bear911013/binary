using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [Header("提示")]
    public GameObject TipObj;
    [Header("對話")]
    public GameObject NPCTalk;
    private void OnMouseDown()
    {
        NPCTalk.SetActive(true);
    }

    //玩家碰到NPC，只觸發程式一次
    private void OnTriggerEnter2D(Collider2D collision)
    {}
    //玩家碰到NPC，沒有離開NPC，持續觸發程式
    private void OnTriggerStay2D(Collider2D collision)
    {}
    //玩家碰到NPC，並離開NPC,只觸發程式一次
    private void OnTriggerExit2D(Collider2D Hit)
    {
        if (Hit.name=="Player")
        {
            TipObj.SetActive(false);
        }
    }
}
