using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // 引入 TextMeshPro 命名空間

public class Timer : MonoBehaviour
{
    public Image radialImage; // 圖片物件，需掛載 Image 組件
    public TextMeshProUGUI countdownText; // 倒數顯示的文字元件 (TextMeshPro)
    public float countdownTime = 180f; // 倒數時間（以秒為單位）
    private float currentTime;
    private float TimeRe;

    public GameObject Die;
    public GameObject Fill;


    // Start is called before the first frame update
    void Start()
    {
        // 初始化時間
        currentTime = countdownTime;

        // 確保圖片的填充方式是 Radial 360
        if (radialImage != null)
        {
            radialImage.type = Image.Type.Filled;
            radialImage.fillMethod = Image.FillMethod.Radial360;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 倒數計時
        if (currentTime > 0 )
        {
            currentTime -= Time.deltaTime;

            // 計算填充比例（從1到0）
            float fillAmount = Mathf.Clamp01(currentTime / countdownTime);

            // 更新圖片填充量
            if (radialImage != null)
            {
                radialImage.fillAmount = fillAmount;
            }

            // 更新文字顯示
            UpdateCountdownText();

            // 更新文字顏色
            UpdateTextColor();
        }
        if(currentTime <= 0)
        {
            Time.timeScale = 0f;
            Die.SetActive(true);
            Fill.SetActive(true);
        }
    }

    // 更新倒數時間文字
    void UpdateCountdownText()
    {
        if (countdownText != null)
        {
            // 將剩餘秒數轉換為整數
            int seconds = Mathf.CeilToInt(currentTime);
            countdownText.text = seconds.ToString(); // 顯示整數秒數
        }
    }

    // 更新文字顏色
    void UpdateTextColor()
    {
        if (countdownText != null)
        {
            // 根據剩餘時間調整顏色
            if (currentTime <= 30) // 30秒內變紅
            {
                countdownText.color = Color.Lerp(Color.yellow, Color.red, (30 - currentTime) / 30);
            }
            else
            {
                countdownText.color = Color.yellow; // 初始顏色為黃色
            }
        }
    }
}
