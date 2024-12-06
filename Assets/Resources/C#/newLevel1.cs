using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class newLevel1 : MonoBehaviour
{
    public Image whiteImage;
    public GameObject white;
    public float fadeDuration = 1f; // 漸變耗時
    private Color originalColor;

    public GameObject P1;
    public GameObject Idle;
    public GameObject Walk;
    public GameObject Run;

    public GameObject P2;

    public float P1Run = 0.08f;
    public GameObject GoatR;
    public float GoatRun = 0.09f;

    public GameObject Talk;
    public GameObject Talk2;
    public GameObject Talk3;
    public GameObject TalkP1;
    public GameObject TalkP2;

    public GameObject CamaraMain;
    public GameObject Camara;
    
    public bool L1;
    public bool L2;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        if (whiteImage != null)
        {
            originalColor = whiteImage.color; // 獲取原始顏色
            StartCoroutine(FadeOut());
        }
        L1 = false;
        L2 = false;

        Talk.SetActive(false);
        TalkP1.SetActive(false);
        TalkP1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        GoatR.transform.position += new Vector3(GoatRun * Time.deltaTime, 0, 0);
        if (P1.transform.position.x < -14.8f && L1 == false)
        {
            P1.transform.position += new Vector3(P1Run * Time.deltaTime, 0, 0);
            Idle.SetActive(false);
            Walk.SetActive(false);
            Run.SetActive(true);
        }
        if (P1.transform.position.x >= -15f && L1 == false)
        {
            Camara.SetActive(true);
            CamaraMain.SetActive(false);
        }
        if (P1.transform.position.x >= -14.875f && L1 ==false)
        {
            Run.GetComponent<SpriteRenderer>().flipX = false;
            Time.timeScale = 0f;
            Talk.SetActive(true);
            TalkP1.SetActive(true);
            TalkP2.SetActive(false);
            if (Input.GetKey(KeyCode.D))
            {
                Run.GetComponent<SpriteRenderer>().flipX = true;
                Idle.SetActive(false);
                Walk.SetActive(true);
                Run.SetActive(false);
                Time.timeScale = 0.5f;
                if (Input.GetKey(KeyCode.D)&& Input.GetKey(KeyCode.LeftShift))
                {
                    L1 = true;
                    Time.timeScale = 1f;
                    Talk.SetActive(false);
                    TalkP1.SetActive(false);
                    TalkP2.SetActive(false);
                    Camara.SetActive(false);
                    CamaraMain.SetActive(true);
                }
            }
        }
        

        // 鏡頭回歸
        if (P1.transform.position.x >= -14.68f && L1 == true &&L2==false)
        {
            P2.transform.position += new Vector3(-P1Run * Time.deltaTime, 0, 0);
            if(P2.transform.position.x<= -14.518f && L1 == true && L2 == false)
            {
                Time.timeScale = 0f;
                Talk2.SetActive(true);
                TalkP1.SetActive(false);
                TalkP2.SetActive(true);
                if (Input.GetKey(KeyCode.Return))
                {
                    Talk2.SetActive(false);
                    TalkP2.SetActive(true);
                    Talk3.SetActive(true);
                    Time.timeScale = 1f;
                    L2 = true;
                }
                
            }
        }
        if (Input.GetKeyUp(KeyCode.Return))
        {
            TalkP2.SetActive(false);
            Talk3.SetActive(false);
        }

    }
    IEnumerator FadeOut()
    {
        float timeElapsed = 0f;

        while (timeElapsed < fadeDuration)
        {
            timeElapsed += Time.deltaTime; 
            float alpha = Mathf.Lerp(1f, 0f, timeElapsed / fadeDuration); // 透明度從1到零
            whiteImage.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }

        // 完全透明，確保設置為完全透明
        whiteImage.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
        white.SetActive(false);
    }
    public void ReloadCurrentScene()
    {
        // 取得當前場景的名稱並重新加載
        SceneManager.LoadScene("SampleScene");
    }
}
