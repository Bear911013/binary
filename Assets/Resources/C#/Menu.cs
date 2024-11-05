using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    [Header("����")]
    public GameObject MenuPage;
    
    [Header("�]�w")]
    public GameObject SettingPage;

    [Header("Ū��")]
    public GameObject LoadPage;

    [Header("�n��")]
    public Slider VoiceSlider;

    [Header("�ѪR��")]
    public Dropdown GameSizeDropdown;
    // Start is called before the first frame update
    void Start()
    {
        AudioListener.volume = VoiceSlider.value;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void ToMovie()
    {
        Application.LoadLevel("Movie");//��ʵe����
    }
    
    public void Quit()
    {
        Application.Quit();//���}
    }
    public void Setting()
    {
        MenuPage.SetActive(true);
        SettingPage.SetActive(true);
    }
    public void SettingExit()
    {
        MenuPage.SetActive(true);
        SettingPage.SetActive(false);
    }
    public void SetLoading(bool Set)
    {   
        MenuPage.SetActive(Set);
        LoadPage.SetActive(!Set);
    }
    public void SetVoice()
    {
        AudioListener.volume = VoiceSlider.value;
        SaveDate.SaveVolume = AudioListener.volume;
    }
    public void SetGameSize()//�ѪR�׿��
    {
        if (GameSizeDropdown.value == 0)
        {
            Screen.SetResolution(1920, 1080, false);
        }
        if (GameSizeDropdown.value == 1)
        {
            Screen.SetResolution(1280, 720, false);
        }
        if (GameSizeDropdown.value == 2)
        {
            Screen.SetResolution(800, 480, false);
        }
    }

}
