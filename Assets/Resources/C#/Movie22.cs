using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Movie22 : MonoBehaviour
{
    //����e�ɼv��
    public VideoPlayer Movie2;
    public float SetTime;
    //�]�w�X��~�i�}�l�����v���O�_���񧹲�
    float NowTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        NowTime += Time.deltaTime;
        if (!Movie2.isPlaying && NowTime > SetTime)
        {
            ToGame();
        }
        //�]�w�v���ݭn�X��~����L
    }
    public void ToGame()
    {
        Application.LoadLevel("Mean");
    }
}
