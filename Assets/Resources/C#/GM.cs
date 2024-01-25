using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    public float T;
    // Start is called before the first frame update
    void Start()
    {
        AudioListener.volume = SaveDate.SaveVolume;
        T = SaveDate.SaveVolume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
