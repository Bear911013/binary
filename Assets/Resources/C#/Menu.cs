using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//����UI��ʽ��
using UnityEngine.SceneManagement;//���������Y�ώ�


public class Menu : MonoBehaviour
{
    [Header("���")]
    public GameObject MenuPage;
    
    [Header("�O��")]
    public GameObject SettingPage;

    [Header("�x�n")]
    public GameObject LoadPage;

    [Header("��������Slider")]
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
        
        Application.LoadLevel("Movie");//�ГQ����"Movie"����
    }
    public void Quit()
    {
        Application.Quit();//�P�]��ʽ
    }
    public void Setting(bool Set)
    {   //�O�����o�_�P
        MenuPage.SetActive(Set);//Set ֵ��true
        SettingPage.SetActive(!Set);//!Set ֵ��false
    }
    public void SetLoading(bool Set)
    {   //�x�n���o�_�P
        MenuPage.SetActive(Set);//Set ֵ��true
        LoadPage.SetActive(!Set);//!Set ֵ��false
    }
    public void SetVoice()//�O�����o�_�P
    {
        //�{�����w������ֵ���0~1֮�g
        AudioListener.volume = VoiceSlider.value;
    }


}
