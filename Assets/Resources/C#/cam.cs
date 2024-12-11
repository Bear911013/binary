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

    public Light lightSource; // �n����O��
    public float xStart = -14.65584f; // ���ܶ}�l����m
    public float xEnd = -11.42998f;   // ���ܵ�������m
    public Color32 startColor = new Color32(0, 0, 255, 255);   // �Ŧ� (#0000FF)
    public Color32 endColor = new Color32(255, 255, 0, 255);  // ���� (#FFFF00)

    public GameObject imageObjectOne; // �Ϥ��@�� GameObject
    public GameObject imageObjectTwo; // �Ϥ��G�� GameObject
    public SpriteRenderer spriteOne; // �Ϥ��@�� SpriteRenderer
    public SpriteRenderer spriteTwo; // �Ϥ��G�� SpriteRenderer
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
            P1Position = P1.transform.position; // �O�s��l��m
        }
        if (P2 != null)
        {
            P2Position = P2.transform.position; // �O�s��l��m
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

        // ����Ū��� x ����
        float x = transform.position.x;

        // �p�G x �b�d��~�A�����C���ܤ�
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
            // �p�� x �b�d�򤺪��k�@�ƭ� (0 �� 1)
            float t = Mathf.InverseLerp(xStart, xEnd, x);

            // �����C��
            lightSource.color = Color.Lerp(startColor, endColor, t);
        }
        float y = Mathf.SmoothStep(0, 1, Mathf.InverseLerp(xStart, xEnd, x));
        // �]�m�Ϥ��z���ס]Alpha�^
        spriteOne.color = new Color(1, 1, 1, 1 - y); // ���ܨ�z��
        spriteTwo.color = new Color(1, 1, 1, y);     // ���ܨ짹�����
    }
}
