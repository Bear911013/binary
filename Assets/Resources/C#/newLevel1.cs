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
    public float fadeDuration = 1f; // ���ܯӮ�
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
    //�Ϥ�
    public GameObject L33;
    public Image L33Image;
    public Sprite[] characterSprites;
    //��r
    public GameObject L34;
    int a = 0;
    private TextMeshProUGUI uiText;
    private string[] messages = new string[]
    {
        "�ڡK�ګ��|�ݨ�o�ǩǲ����F��H",
        "�A�S�O����F��H",
        "�o�ǬO�c���C",
        "�A�O���O�o��F�������H�ҥH��ݨ����̩M�ڡH",
        "���A�A��ߡA�ڤ��|�ˮ`�A",
        "�������򥦭̷|�l�ۧڡH�L�̷|�ˮ`�ڶܡH",
        "�A�i�ण�p�ߧl�ޤF����",
        "���H�ݱo���F��@�볣�O�K�r���ΥX�F�N�~",
        "�ﰭ�ӻ��A�A�ܮe���Q�X��ӤJ",
        "���ڸӫ���H",
        "��......",
        "�ڦ��@�ۡA�i�H���A�Ȯ����ά��H���𮧡C",
        "�]���X�⦡)�����믫�A�M�ڰ��@��",
        " ",
        "�h�m�X���N���m�F",
        "�o�O�ڪ��F�O",
        "�ȮɭɧA��",
        "���ƻ�n���ڡH",
        "�����D�A�ݧA���t�a",
        "�A�ܭ����A�ګܳ��w�A",
        "......",
        " "
    };//���
    private int currentIndex = 3;
    public GameObject L35;
    public bool L4;
    private float holdTime = 0f; // �Ψӭp������ɶ�
    private bool isPressing = false; // �P�_�O�_���b����
    private bool isLongPressComplete = false; // �P�_�����O�_�F��
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
            uiText = textObject.GetComponent<TextMeshProUGUI>(); // �אּ���o TextMeshProUGUI �ե�
            if (uiText != null)
            {
                Debug.Log("Text123 ����W�� TextMeshProUGUI �ե�");
                // �w�]��ܲĤ@�y��
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

        // ���Y�^�k
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

            // ���� P1 ���d��
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
                        // ��ܥ�ø 1�]�ĤG�i�Ϥ��^
                        L33Image.sprite = characterSprites[1];
                    }
                    if (currentIndex == 1 || currentIndex == 5 || currentIndex == 9)
                    {
                        // ��ܥ�ø 1�]�ĤG�i�Ϥ��^
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
            // �p�G���b����A�p������ɶ�
            if (!isPressing)
            {
                isPressing = true;
                holdTime = 0f;
            }

            // �֥[�ɶ�
            holdTime += Time.deltaTime;

            // �p�G�����F����A��ܫH��
            if (holdTime >= 2f && !isLongPressComplete)
            {
                isLongPressComplete = true;
                Debug.Log("�� ���F���");
            }
        }
        else
        {
            // �p�G��}�ť���A�åB�����w����
            if (isPressing && isLongPressComplete)
            {
                Debug.Log("�L�F���");
                L35.SetActive(false);
                // ���m���A
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
                    // ��ܥ�ø 1�]�ĤG�i�Ϥ��^
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
            float alpha = Mathf.Lerp(1f, 0f, timeElapsed / fadeDuration); // �z���ױq1��s
            whiteImage.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }

        // �����z���A�T�O�]�m�������z��
        whiteImage.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
        white.SetActive(false);
    }
    public void ReloadCurrentScene()
    {
        // ���o��e�������W�٨í��s�[��
        SceneManager.LoadScene("SampleScene");
    }
}
