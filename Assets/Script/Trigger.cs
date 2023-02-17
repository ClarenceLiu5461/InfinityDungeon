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

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.name == "Up")
        {
            Door.SetActive(false);
            Debug.Log("Bruh"); //Make sure it's available
        }
        if (collision.gameObject.name == "Right")
        {
            Door.SetActive(false);
        }
        if (collision.gameObject.name == "Bottom")
        {
            Door.SetActive(false);
        }
        if (collision.gameObject.name == "Left")
        {
            Door.SetActive(false);
        }
    }
}