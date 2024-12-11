using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro; 

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
    public GameObject IdleP2;
    public GameObject WalkP2;
    public GameObject RunP2;

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
    public GameObject Camara2;

    public bool L1;
    public GameObject L11;
    public bool L2;
    public GameObject L21;
    public GameObject L22;
    public GameObject Enter;
    public bool L3;
    public GameObject L31;
    public GameObject L32;
    //圖片
    public GameObject L33;
    public Image L33Image;
    public Sprite[] characterSprites;
    //文字
    public GameObject L34;
    int a = 0;
    private TextMeshProUGUI uiText;
    private string[] messages = new string[]
    {
        "我…我怎麼會看到這些怪異的東西？",
        "你又是什麼東西？",
        "這些是惡鬼。",
        "你是不是得到了陰陽眼？所以能看見它們和我？",
        "阿，你放心，我不會傷害你",
        "那為什麼它們會追著我？他們會傷害我嗎？",
        "你可能不小心吸引了它們",
        "活人看得見靈體一般都是八字輕或出了意外",
        "對鬼來說，你很容易被趁虛而入",
        "那我該怎麼辦？",
        "嗯......",
        "我有一招，可以幫你暫時隱匿活人的氣息。",
        "（做出手式)集中精神，和我做一次",
        " ",
        "多練幾次就熟練了",
        "這是我的靈力",
        "暫時借你用",
        "為甚麼要幫我？",
        "不知道，看你眼緣吧",
        "你很面熟，我很喜歡你",
        "......",
        " "
    };//對話
    private int currentIndex = 3;
    public GameObject L35;
    public bool L4;
    private float holdTime = 0f; // 用來計算長按時間
    private bool isPressing = false; // 判斷是否正在長按
    private bool isLongPressComplete = false; // 判斷長按是否達成
    public bool L5;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;

        L1 = false;
        L2 = false;
        L3 = false;
        L4 = false;

        Talk.SetActive(false);
        TalkP1.SetActive(false);
        TalkP1.SetActive(false);
        Invoke("FindTextObject", 0.1f);
    }
    void FindTextObject()
    {
        GameObject textObject = GameObject.Find("Canvas/Talk/L3/Text123");
        if (textObject != null)
        {
            uiText = textObject.GetComponent<TextMeshProUGUI>(); // 改為取得 TextMeshProUGUI 組件
            if (uiText != null)
            {
                Debug.Log("Text123 物件上有 TextMeshProUGUI 組件");
                // 預設顯示第一句話
                uiText.text = messages[0];
            }
        }
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
            L11.SetActive(true);
            Talk.SetActive(true);
            TalkP1.SetActive(true);
            TalkP2.SetActive(false);
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                Run.GetComponent<SpriteRenderer>().flipX = true;
                Idle.SetActive(false);
                Walk.SetActive(true);
                Run.SetActive(false);
                Time.timeScale = 0.2f;
                if (Input.GetKey(KeyCode.D)&& Input.GetKey(KeyCode.LeftShift))
                {
                    L1 = true;
                    Time.timeScale = 1f;
                    Talk.SetActive(false);
                    TalkP1.SetActive(false);
                    TalkP2.SetActive(false);
                    Camara.SetActive(false);
                    CamaraMain.SetActive(true);
                    L11.SetActive(false);
                }
            }
        }

        // 鏡頭回歸
        if (P1.transform.position.x >= -14.68f && L1 == true &&L2==false)
        {
            P2.transform.position += new Vector3(-P1Run * Time.deltaTime, 0, 0);
            IdleP2.SetActive(false);
            WalkP2.SetActive(true);
            RunP2.SetActive(false);
            if (P2.transform.position.x <= -14.4f && L1 == true && L2 == false)
            {
                Time.timeScale = 0f;
                Camara2.SetActive(true);
                CamaraMain.SetActive(false);
                TalkP1.SetActive(false);
                TalkP2.SetActive(true);
                L21.SetActive(true);
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    Talk2.SetActive(false);
                    Talk3.SetActive(true);
                }
                if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
                {
                    Time.timeScale = 0.2f;
                    L21.SetActive(false);
                    RunP2.SetActive(false);
                    if (Input.GetKey(KeyCode.RightShift))
                    {
                        Time.timeScale = 1f;
                    }
                }
                if (P2.transform.position.x <= -14.45f && L1 == true && L2 == false)
                {
                    Enter.SetActive(false);
                    Camara2.transform.position = new Vector3(-14.508f, Camara2.transform.position.y,Camara2.transform.position.z);
                }
                if (P2.transform.position.x <= -14.518f && L1 == true && L2 == false)
                {
                    Enter.SetActive(false);
                    L21.SetActive(false);
                    Time.timeScale = 0f;
                    L22.SetActive(true);
                    if (Input.GetKey(KeyCode.Return))
                    {
                        Time.timeScale = 1f;
                        L2 = true;
                        Camara2.SetActive(false);
                        CamaraMain.SetActive(true);
                        L22.SetActive(false);
                    }

                }
            }
                
        }
        if (Input.GetKeyUp(KeyCode.Return))
        {
            TalkP2.SetActive(false);
            Talk3.SetActive(false);
        }
        if (L2 == true)
        {

            // 限制 P1 的範圍
            if (P2.transform.position.x >= P1.transform.position.x + 0.314f)
            {
                P2.transform.position = new Vector3(P1.transform.position.x + 0.314f, P2.transform.position.y, P2.transform.position.z);
            }
            if (P2.transform.position.x <= P1.transform.position.x - 0.27797f)
            {
                P2.transform.position = new Vector3(P1.transform.position.x - 0.27797f, P2.transform.position.y, P2.transform.position.z);

            }
        }
        if (L2 == true && L3 == false)
        {
            if (P1.transform.position.x < P2.transform.position.x + 0.0455f && P1.transform.position.x > P2.transform.position.x - 0.0455f)
            {
                L31.SetActive(true);
            }
            else
            {
                L31.SetActive(false);
            }
                if (P1.transform.position.x < P2.transform.position.x + 0.016f && P1.transform.position.x > P2.transform.position.x - 0.016f && P1.transform.position.y > P2.transform.position.y - 0.01f && P1.transform.position.y < P2.transform.position.y + 0.01f)
            {
                L32.SetActive(true);
                if (Input.GetKeyUp(KeyCode.Space)&& a == 0)
                {
                    currentIndex = 0;
                    Time.timeScale = 0f;
                    L33.SetActive(true);
                    L34.SetActive(true);
                    a = 1;
                    L33Image.sprite = characterSprites[0];
                }
                if (Input.anyKeyDown&& a == 1)
                {
                    currentIndex++;
                    uiText.text = messages[currentIndex];
                    if (currentIndex == 2 || currentIndex == 3 || currentIndex == 4 || currentIndex == 6 || currentIndex == 7 || currentIndex == 8 || currentIndex ==10 || currentIndex == 11 || currentIndex == 12 )
                    {
                        // 顯示立繪 1（第二張圖片）
                        L33Image.sprite = characterSprites[1];
                    }
                    if (currentIndex == 1 || currentIndex == 5 || currentIndex == 9)
                    {
                        // 顯示立繪 1（第二張圖片）
                        L33Image.sprite = characterSprites[0];
                    }
                }
                if (currentIndex == 13)
                {
                    if (Input.anyKeyDown && a == 1)
                    {
                        L33.SetActive(false);
                        L34.SetActive(false);
                        Time.timeScale = 0.01f;
                        L35.SetActive(true);
                        L3 = true;
                        L31.SetActive(false);
                        L32.SetActive(false);
                    }
                }

            }
            else
            {
                Time.timeScale = 1f;
                L32.SetActive(false);
            }
        }
        if (Input.GetKey(KeyCode.Space)&&L3==true&&L4==false)
        {

            Time.timeScale = 1f;
            // 如果正在按住，計算長按時間
            if (!isPressing)
            {
                isPressing = true;
                holdTime = 0f;
            }

            // 累加時間
            holdTime += Time.deltaTime;

            // 如果長按達到兩秒，顯示信息
            if (holdTime >= 2f && !isLongPressComplete)
            {
                isLongPressComplete = true;
                Debug.Log("我 按了兩秒");
            }
        }
        else
        {
            // 如果放開空白鍵，並且長按已完成
            if (isPressing && isLongPressComplete)
            {
                Debug.Log("過了兩秒");
                L35.SetActive(false);
                // 重置狀態
                isPressing = false;
                isLongPressComplete = false;
                holdTime = 0f;
                L4 = true;
            }
        }
        if(L4 == true && L5 == false)
        {
            if (a == 1)
            {
                Time.timeScale = 0f;
                L33.SetActive(true);
                L34.SetActive(true);
                currentIndex = 14;
                uiText.text = messages[currentIndex];
                a = 2;
            }
            if (Input.anyKeyDown && a == 2)
            {
                currentIndex++;
                uiText.text = messages[currentIndex];
                if (currentIndex == 17 || currentIndex == 20)
                {
                    // 顯示立繪 1（第二張圖片）
                    L33Image.sprite = characterSprites[0];
                }
                else
                {
                    L33Image.sprite = characterSprites[1];
                }
            }
            if (currentIndex == 21)
            {
                if (Input.anyKeyDown && a == 2)
                {
                    L33.SetActive(false);
                    L34.SetActive(false);
                    Time.timeScale = 1f;
                    L5 = true;
                }
            }
        }
        
    }


    IEnumerator FadeOut()
    {
        float timeElapsed = 0f;
        if (white != null)
        {
            white.SetActive(true);
        }
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
