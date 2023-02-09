using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject Door;
    public Dictionary<string, GameObject> ObjList = new Dictionary<string, GameObject>();
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
            Door.SetActive(false);
        }
        if (collision.gameObject.name == "RightDoor")
        {
            Door.SetActive(false);
        }
        if (collision.gameObject.name == "BottomDoor")
        {
            Door.SetActive(false);
        }
        if (collision.gameObject.name == "LeftDoor")
        {
            Door.SetActive(false);
        }
    }
}