using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject Door;
    public Dictionary<string, GameObject> ObjList = new Dictionary<string, GameObject>();
    void Start()
    {
        ObjList.Add("Door",Door);
        GetObj("Door");
    }

    public void GetObj(string name)
    {
        if (ObjList.ContainsKey(name))
        {
            Door = ObjList[name];
        }
    }

    void Update()
    {
        
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.name == "UpDoor")
        {
            ObjList["Door"].SetActive(false);
            Debug.Log("Bruh"); //Make sure it's available
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