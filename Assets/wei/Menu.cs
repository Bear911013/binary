using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ToMovie()
    {
        Application.LoadLevel("Game");//ÇÐ“Qˆö¾°"Game"ˆö¾°
    }
    public void Quit()
    {
        Application.Quit();//êPé]³ÌÊ½
    }
}
