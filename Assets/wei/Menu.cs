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
        Application.LoadLevel("Game");//�ГQ����"Game"����
    }
    public void Quit()
    {
        Application.Quit();//�P�]��ʽ
    }
}
