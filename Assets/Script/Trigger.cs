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
    }

    public void GetObj(string id)
    {
        if (ObjList.ContainsKey(id))
        {
            GameObject GetObj = ObjList[id];
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