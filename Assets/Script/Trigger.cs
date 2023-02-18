using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject UpDoor,RightDoor,BottomDoor,LeftDoor;
    public Dictionary<string, GameObject> ObjList = new Dictionary<string, GameObject>();
    void Start()
    {
        //ObjList.Add("Door",Door);
        //GetObj("Door");
    }

    public void GetObj(string name)
    {
        if (ObjList.ContainsKey(name))
        {
            //Door = ObjList[name];
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.name == "Up")
        {
            UpDoor.SetActive(false);
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