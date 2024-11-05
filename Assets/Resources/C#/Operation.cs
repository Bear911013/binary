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

    //�o�O�C���ާ@
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
        // ���ݨ�����]��ڮɶ��A�Ӥ��O�C���ɶ��^
        yield return new WaitForSecondsRealtime(2f);
        // �N�ɶ���ҳ]��0�A�ϹC���ɶ��Ȱ�
        Time.timeScale = 0f;

        // ��� "Talk" UI �l����
        if (Talk != null)
        {
            Talk.SetActive(true);
        }

        // ���ݨ�����]��ڮɶ��A�Ӥ��O�C���ɶ��^
        yield return new WaitForSecondsRealtime(2f);

        // ��_�ɶ���Ҭ�1�A�ϹC���ɶ���_���`
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
