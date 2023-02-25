using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainAdd : MonoBehaviour
{
    public Trigger GetTrigger;
    public GameObject Room;
    public GameObject CreateRoom;
    // Start is called before the first frame update
    void Start()
    {
        CreateRoom = Instantiate(Room, new Vector3(0, 0, 0), Quaternion.identity);
        GetTrigger.BottomDoor = CreateRoom.GetComponent<SetDoor>().Doors[0];
        GetTrigger.UpDoor = CreateRoom.GetComponent<SetDoor>().Doors[1];
        GetTrigger.LeftDoor = CreateRoom.GetComponent<SetDoor>().Doors[2];
        GetTrigger.RightDoor = CreateRoom.GetComponent<SetDoor>().Doors[3];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
