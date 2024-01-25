using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//新增UI程式庫
using UnityEngine.SceneManagement;//新增場景資料庫


public class Menu : MonoBehaviour
{
    [Header("首頁")]
    public GameObject MenuPage;
    
    [Header("設定")]
    public GameObject SettingPage;

    [Header("讀檔")]
    public GameObject LoadPage;

    [Header("控制音量Slider")]
    public Slider VoiceSlider;

    // Start is called before the first frame update
    void Start()
    {
        AudioListener.volume = VoiceSlider.value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToMovie()
    {
        
        Application.LoadLevel("Movie");//切換場景"Movie"場景
    }
    public void Quit()
    {
        Application.Quit();//關閉程式
    }
    public void Setting(bool Set)
    {   //設定按鈕開關
        MenuPage.SetActive(Set);//Set 值為true
        SettingPage.SetActive(!Set);//!Set 值為false
    }
    public void SetLoading(bool Set)
    {   //讀檔按鈕開關
        MenuPage.SetActive(Set);//Set 值為true
        LoadPage.SetActive(!Set);//!Set 值為false
    }
    public void SetVoice()//設定按鈕開關
    {
        //調整整體音量，值介於0~1之間
        AudioListener.volume = VoiceSlider.value;
    }


}
