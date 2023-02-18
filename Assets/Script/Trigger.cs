using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject UpDoor,RightDoor,BottomDoor,LeftDoor;
    public Dictionary<string, GameObject> ObjList = new Dictionary<string, GameObject>();
    void Start()
    {
        ObjList.Add("UpDoor", UpDoor);               //Add UpDoor
        ObjList.Add("RightDoor", RightDoor);       //Add RightDoor
        ObjList.Add("BottomDoor", BottomDoor); //Add BottomDoor
        ObjList.Add("LeftDoor", LeftDoor);           //Add LeftDoor
        AddItem("UpDoor");
        AddItem("RightDoor");
        AddItem("BottomDoor");
        AddItem("LeftDoor");
    }

    //Make sure keys exist
    public void AddItem(string name)
    {
        if (ObjList.ContainsKey(name))
        {
            Debug.Log(name + "Exists");
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.name == "Up")
        {
            ObjList["UpDoor"].SetActive(false);
            Debug.Log("Bruh"); //Make sure it's available
        }
        if (collision.gameObject.name == "Right")
        {
            RightDoor.SetActive(false);
        }
        if (collision.gameObject.name == "Bottom")
        {
            BottomDoor.SetActive(false);
        }
        if (collision.gameObject.name == "Left")
        {
            LeftDoor.SetActive(false);
        }
    }
}