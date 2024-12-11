using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{
    public GameObject P1;
    public GameObject P2;
    private Vector3 P1Position;
    private Vector3 P2Position;
    private Vector3 Position;
    public GameObject Camra;
    public Vector3 Camra1;

    public Light lightSource; // 要控制的燈光
    public float xStart = -14.65584f; // 漸變開始的位置
    public float xEnd = -11.42998f;   // 漸變結束的位置
    public Color32 startColor = new Color32(0, 0, 255, 255);   // 藍色 (#0000FF)
    public Color32 endColor = new Color32(255, 255, 0, 255);  // 黃色 (#FFFF00)

    public GameObject imageObjectOne; // 圖片一的 GameObject
    public GameObject imageObjectTwo; // 圖片二的 GameObject
    public SpriteRenderer spriteOne; // 圖片一的 SpriteRenderer
    public SpriteRenderer spriteTwo; // 圖片二的 SpriteRenderer
    // Start is called before the first frame update
    void Start()
    {
        Position.z = -1.215526f;
        if (imageObjectOne != null) spriteOne = imageObjectOne.GetComponent<SpriteRenderer>();
        if (imageObjectTwo != null) spriteTwo = imageObjectTwo.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Camra1 = Camra.transform.position;
        if (P1 != null)
        {
            P1Position = P1.transform.position; // 保存初始位置
        }
        if (P2 != null)
        {
            P2Position = P2.transform.position; // 保存初始位置
        }
        Position.x = (P1Position.x + P2Position.x) / 2;
        Position.y = (P1Position.y + P2Position.y) / 2;
        if (Position.x <= -14.65584f)
        {
            Position = new Vector3(-14.65584f, Position.y, -1.215526f);
        }
        if (Position.x >= -11.42998f)
        {
            Position = new Vector3(-11.42998f, Position.y, -1.215526f);
        }
        gameObject.transform.position = Position;

        // 獲取空物件的 x 坐標
        float x = transform.position.x;

        // 如果 x 在範圍外，不做顏色變化
        if (x < xStart)
        {
            lightSource.color = startColor;
        }
        else if (x > xEnd)
        {
            lightSource.color = endColor;
        }
        else
        {
            // 計算 x 在範圍內的歸一化值 (0 到 1)
            float t = Mathf.InverseLerp(xStart, xEnd, x);

            // 插值顏色
            lightSource.color = Color.Lerp(startColor, endColor, t);
        }
        float y = Mathf.SmoothStep(0, 1, Mathf.InverseLerp(xStart, xEnd, x));
        // 設置圖片透明度（Alpha）
        spriteOne.color = new Color(1, 1, 1, 1 - y); // 漸變到透明
        spriteTwo.color = new Color(1, 1, 1, y);     // 漸變到完全顯示
    }
}
