using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [Header("暫停")]
    public GameObject StopPage;
    [Header("設定")]
    public GameObject SetPage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Stopting()
    {
        StopPage.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Setting()
    {
        SetPage.SetActive(true);
    }
    public void SettingExit()
    {
        Time.timeScale = 1f;
        SetPage.SetActive(false);
        StopPage.SetActive(false);
    }
    public void ToMovie()
    {
        Application.LoadLevel("Menu");//到動畫場景
    }
    public void ToMovie2()
    {
        Application.LoadLevel("Movie2");
    }

}
