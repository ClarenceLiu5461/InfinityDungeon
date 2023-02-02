using System.Collections;
using UnityEngine;
using UnityEngine.UI;



public class TimefgControl : MonoBehaviour
{
    public Text valueText;
    public static int maxValue;
    public static int currentValue;
    private Image image;

    
    void start()
    {
        image = GetComponent<Image>();
    }

    void Update()
    {
        image.fillAmount = (float)currentValue / (float)60;
    }
    

}