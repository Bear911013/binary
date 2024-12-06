using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text : MonoBehaviour
{
    internal Font font;

    public int fontSize { get; internal set; }
    public TextAnchor alignment { get; internal set; }
    public string text { get; internal set; }

    void Awake()//初始狀態，程式開啟必執行一次
    {
        Debug.Log("Hello");
    }
    // Start is called before the first frame update
    void Start()//初始狀態，物件開啟執行一次
    {
        Debug.Log("Hello World");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
