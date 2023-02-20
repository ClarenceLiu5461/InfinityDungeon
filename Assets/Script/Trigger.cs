using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject UpDoor,RightDoor,BottomDoor,LeftDoor;
    public Dictionary<string, GameObject> ObjList = new Dictionary<string, GameObject>(); //Dictionary which keeps doors
    void Start()
    {
        ObjList.Add("UpDoor", UpDoor);               //Add UpDoor
        ObjList.Add("RightDoor", RightDoor);       //Add RightDoor
        ObjList.Add("BottomDoor", BottomDoor); //Add BottomDoor
        ObjList.Add("LeftDoor", LeftDoor);           //Add LeftDoor
    }

    //Make sure keys exist
    public void SetDoor(string name)
    {
        if (ObjList.ContainsKey(name))
        {
            ObjList[name].SetActive(false);
            Debug.Log(name+"Exists");
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.name == "Up")
        {
            SetDoor("UpDoor");
        }
        if (collision.gameObject.name == "Right")
        {
            SetDoor("RightDoor");
        }
        if (collision.gameObject.name == "Bottom")
        {
            SetDoor("BottomDoor");
        }
        if (collision.gameObject.name == "Left")
        {
            SetDoor("LeftDoor");
        }
    }
}