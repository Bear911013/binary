using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Operation : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject W;
    public GameObject A;
    public GameObject D;
    public GameObject Space;
    public GameObject SpaceT;
    public GameObject U;
    public GameObject L;
    public GameObject R;
    public GameObject Enter;
    public GameObject UT;
    public GameObject LT;
    public GameObject RT;
    public GameObject EnterT;

    public Canvas uiCanvas;
    public GameObject Talk;

    //這是遊戲操作
    void Start()
    {
        UT.SetActive(false);
        LT.SetActive(false);
        RT.SetActive(false);
        EnterT.SetActive(false);
        SpaceT.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        W.SetActive(true);
        A.SetActive(true);
        D.SetActive(true);
        Space.SetActive(true);
        U.SetActive(true);
        L.SetActive(true);
        R.SetActive(true);
        Enter.SetActive(true);

        if (Input.GetKey(KeyCode.W))
        {
            W.SetActive(false);
        }
        if (Input.GetKey(KeyCode.A))
        {
            A.SetActive(false);
        }
        if (Input.GetKey(KeyCode.D))
        {
            D.SetActive(false);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            Space.SetActive(false);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            U.SetActive(false);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            L.SetActive(false);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            R.SetActive(false);
        }
        if (Input.GetKey(KeyCode.Return))
        {
            Enter.SetActive(false);
        }
    }
    public void PauseGameTime()
    {
        StartCoroutine(PauseAndResumeTime());
        
    }

    private IEnumerator PauseAndResumeTime()
    {
        // 等待兩秒鐘（實際時間，而不是遊戲時間）
        yield return new WaitForSecondsRealtime(2f);
        // 將時間比例設為0，使遊戲時間暫停
        Time.timeScale = 0f;

        // 顯示 "Talk" UI 子物件
        if (Talk != null)
        {
            Talk.SetActive(true);
        }

        // 等待兩秒鐘（實際時間，而不是遊戲時間）
        yield return new WaitForSecondsRealtime(2f);

        // 恢復時間比例為1，使遊戲時間恢復正常
        Time.timeScale = 1f;

        UT.SetActive(true);
        LT.SetActive(true);
        RT.SetActive(true);
        EnterT.SetActive(true);
        SpaceT.SetActive(true);
        U.SetActive(true);
        L.SetActive(true);
        R.SetActive(true);
        Enter.SetActive(true);

        Talk.SetActive(false);
    }
    
}
