using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    public enum Direction {LeftUp,MidUp,RightUp,LeftCenter,MidCenter,RightCenter,LeftBottom,MidBottom,RightBottom};
    public Direction direction;
    GameObject Player;

    [Header("Room Information")]
    public GameObject roomPrefab;
    public int roomNumber;
    public int generateRoom = 0;

    [Header("Position Control")]
    public Transform generatorPoint;
    public float roomMove;

    public List<GameObject> rooms = new List<GameObject>();

    void Start()
    {
        this.Player = GameObject.Find("Player");
        for (int i = 0; i < roomNumber; i++)
        {
            //Change Point Position
            ChangePointPos();
            generateRoom++;
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
        direction = (Direction)generateRoom;
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

    public void OnColliderEnter(Collision Main)
    {
        if (Main.collider.name.Contains("door"))
        {
            generatorPoint.position = new Vector3(0, 0, 0);
        }
    }
}