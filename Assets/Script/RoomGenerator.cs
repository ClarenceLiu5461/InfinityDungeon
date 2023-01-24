using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    public enum Direction {LeftUp,MidUp,RightUp,LeftCenter,MidCenter,RightCenter,LeftBottom,MidBottom,RightBottom};
    public Direction direction;

    [Header("Room Information")]
    public GameObject roomPrefab;
    public int roomNumber;
    public int generatedRoom = 0;

    [Header("Position Control")]
    public Transform generatorPoint;
    public static float roomMove = 13.5f;

    public List<GameObject> rooms = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < roomNumber; i++)
        {
            //Change Point Position
            ChangePointPos();
            generatedRoom++;
            //Generate Rooms
            Instantiate(roomPrefab, generatorPoint.position, Quaternion.identity);
            generatorPoint.position = new Vector3(0, 0, 0);
        }
    }

    
    void Update()
    {
        
    }

    public void ChangePointPos()
    {
        direction = (Direction)generatedRoom;
        switch (direction)
        {
            case Direction.LeftUp:
                generatorPoint.position += new Vector3(-roomMove, 0, roomMove);
                break;
            case Direction.MidUp:
                generatorPoint.position += new Vector3(0, 0, roomMove);
                break;
            case Direction.RightUp:
                generatorPoint.position += new Vector3(roomMove, 0, roomMove);
                break;
            case Direction.LeftCenter:
                generatorPoint.position += new Vector3(-roomMove, 0, 0);
                break;
            case Direction.MidCenter:
                generatorPoint.position += new Vector3(0, 0, 0);
                break;
            case Direction.RightCenter:
                generatorPoint.position += new Vector3(roomMove, 0, 0);
                break;
            case Direction.LeftBottom:
                generatorPoint.position += new Vector3(-roomMove, 0, -roomMove);
                break;
            case Direction.MidBottom:
                generatorPoint.position += new Vector3(0, 0, -roomMove);
                break;
            case Direction.RightBottom:
                generatorPoint.position += new Vector3(roomMove, 0, -roomMove);
                break;
        }
    }
}
