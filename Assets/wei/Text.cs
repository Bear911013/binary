using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text : MonoBehaviour
{
    internal Font font;

    public int fontSize { get; internal set; }
    public TextAnchor alignment { get; internal set; }
    public string text { get; internal set; }

    void Awake()//��ʼ��B����ʽ�_���؈���һ��
    {
        Debug.Log("Hello");
    }
    // Start is called before the first frame update
    void Start()//��ʼ��B������_������һ��
    {
        Debug.Log("Hello World");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
