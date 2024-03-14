using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MovieGM : MonoBehaviour
{
    //播放前導影片
    public VideoPlayer Movie;
    public float SetTime;
    //設定幾秒才可開始偵測影片是否撥放完畢
    float NowTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        NowTime += Time.deltaTime;
        if(!Movie.isPlaying&& NowTime> SetTime)
        {   
            ToGame();
        }
        //設定影片需要幾秒才能跳過
}
    public void ToGame()
    {
        Application.LoadLevel("SampleScene");
    }
}