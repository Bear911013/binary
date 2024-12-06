using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // �ޤJ TextMeshPro �R�W�Ŷ�

public class Timer : MonoBehaviour
{
    public Image radialImage; // �Ϥ�����A�ݱ��� Image �ե�
    public TextMeshProUGUI countdownText; // �˼���ܪ���r���� (TextMeshPro)
    public float countdownTime = 180f; // �˼Ʈɶ��]�H�����^
    private float currentTime;
    private float TimeRe;

    public GameObject Die;
    public GameObject Fill;


    // Start is called before the first frame update
    void Start()
    {
        // ��l�Ʈɶ�
        currentTime = countdownTime;

        // �T�O�Ϥ�����R�覡�O Radial 360
        if (radialImage != null)
        {
            radialImage.type = Image.Type.Filled;
            radialImage.fillMethod = Image.FillMethod.Radial360;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // �˼ƭp��
        if (currentTime > 0 )
        {
            currentTime -= Time.deltaTime;

            // �p���R��ҡ]�q1��0�^
            float fillAmount = Mathf.Clamp01(currentTime / countdownTime);

            // ��s�Ϥ���R�q
            if (radialImage != null)
            {
                radialImage.fillAmount = fillAmount;
            }

            // ��s��r���
            UpdateCountdownText();

            // ��s��r�C��
            UpdateTextColor();
        }
        if(currentTime <= 0)
        {
            Time.timeScale = 0f;
            Die.SetActive(true);
            Fill.SetActive(true);
        }
    }

    // ��s�˼Ʈɶ���r
    void UpdateCountdownText()
    {
        if (countdownText != null)
        {
            // �N�Ѿl����ഫ�����
            int seconds = Mathf.CeilToInt(currentTime);
            countdownText.text = seconds.ToString(); // ��ܾ�Ƭ��
        }
    }

    // ��s��r�C��
    void UpdateTextColor()
    {
        if (countdownText != null)
        {
            // �ھڳѾl�ɶ��վ��C��
            if (currentTime <= 30) // 30���ܬ�
            {
                countdownText.color = Color.Lerp(Color.yellow, Color.red, (30 - currentTime) / 30);
            }
            else
            {
                countdownText.color = Color.yellow; // ��l�C�⬰����
            }
        }
    }
}
