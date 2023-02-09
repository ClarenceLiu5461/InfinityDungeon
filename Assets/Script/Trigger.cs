using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject NewObj;
    public Dictionary<string, GameObject> ObjList = new Dictionary<string, GameObject>();
    void Start()
    {
        ObjList.Add("Door",NewObj);
    }

    public void GetObj(string id)
    {
        if (ObjList.ContainsKey(id))
        {
            NewObj = ObjList[id];
        }
    }

    void Update()
    {
        
    }

    private void OnTriggerStay(Collider collision)
    {
        GetObj("Door");
        if (collision.gameObject.name == "UpDoor")
        {
            NewObj.SetActive(false);
        }
        if (collision.gameObject.name == "RightDoor")
        {
            NewObj.SetActive(false);
        }
        if (collision.gameObject.name == "BottomDoor")
        {
            NewObj.SetActive(false);
        }
        if (collision.gameObject.name == "LeftDoor")
        {
            NewObj.SetActive(false);
        }
    }
}