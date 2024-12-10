using UnityEngine;
using UnityEngine.UI;

public class CanvasHierarchyPrinter : MonoBehaviour
{
    public Text myText;

    void Start()
    {
        if (myText != null)
        {
            myText.text = "Hello, World!";
        }
    }

}
