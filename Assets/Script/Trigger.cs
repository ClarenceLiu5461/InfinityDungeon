using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    private Vector3 PlayerRecordPos;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "UpDoor")
        {
            GameObject.Find("MainCamera").transform.position += new Vector3(0,0,12);
            //this.gameObject.transform.position += new Vector3(0, 0, 3);
        }
        if (collision.gameObject.name == "RightDoor")
        {
            GameObject.Find("MainCamera").transform.position += new Vector3(12, 0, 0);
            //this.gameObject.transform.position += new Vector3(3, 0, 0);
        }
        if (collision.gameObject.name == "BottomDoor")
        {
            GameObject.Find("MainCamera").transform.position += new Vector3(0, 0, -12);
            //this.gameObject.transform.position += new Vector3(0, 0, -3);
        }
        if (collision.gameObject.name == "LeftDoor")
        {
            GameObject.Find("MainCamera").transform.position += new Vector3(-12, 0, 0);
            //this.gameObject.transform.position += new Vector3(-3, 0, 0);
        }
    }
}
