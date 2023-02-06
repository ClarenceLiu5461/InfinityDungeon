using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject Door = GameObject.FindWithTag("Door");
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
            GameObject.Find("MainCamera").transform.position += new Vector3(0, 0, 12);
            Door.SetActive(false);
        }
        if (collision.gameObject.name == "RightDoor")
        {
            GameObject.Find("MainCamera").transform.position += new Vector3(12, 0, 0);
            Door.SetActive(false);
        }
        if (collision.gameObject.name == "BottomDoor")
        {
            GameObject.Find("MainCamera").transform.position += new Vector3(0, 0, -12);
            Door.SetActive(false);
        }
        if (collision.gameObject.name == "LeftDoor")
        {
            GameObject.Find("MainCamera").transform.position += new Vector3(-12, 0, 0);
            Door.SetActive(false);
        }
    }
}