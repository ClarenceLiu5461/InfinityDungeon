using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    static int time_i = 60;
    bool start_Timer3 = true;
    public Image timeeeee ;
    
    

    void Start()
    {
    }
    
    IEnumerator timer3()
    {
        yield return new WaitForSeconds(1f);
        time_i--;
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
            Debug.Log(time_i);
        }
    }
    
    
   

}