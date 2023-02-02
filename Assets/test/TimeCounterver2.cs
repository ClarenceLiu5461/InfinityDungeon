using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounterver2 : MonoBehaviour
{
    static float time_i = 60;
    bool start_Timer3 = true;
    public Image timeeeee ;
    
    

    void Start()
    {
    }

    IEnumerator timer3()
    {
        yield return new WaitForSeconds(0.1f);
        time_i -= 0.1f;
        start_Timer3 = true;
    }

    void Update()
    {
        if (start_Timer3)
        {
            StartCoroutine("timer3");
            timeeeee = this.gameObject.GetComponent<Image>();
            timeeeee.fillAmount = time_i / 60f;
            start_Timer3 = false;
        }
    }
    
    
   

}