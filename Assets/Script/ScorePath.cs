using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePath : MonoBehaviour
{
    public GameObject Path;
    public GameObject Minus;
    public GameObject GeneratePoint;
    public AudioClip RightWay;
    public AudioClip WrongWay;
    public Dictionary<int, GameObject> PathList = new Dictionary<int, GameObject>(); //Dictionary which keeps paths
    AudioSource audiosource;

    private Vector3 Pposition; //GeneratePoint's last position
    private int Score = 0;
    void Start()
    {
        //Generate the first path
        GeneratePath();
        //Get AudioSource
        audiosource = GetComponent<AudioSource>();
    }

    public void GeneratePath()
    {
        //Clear PathList
        PathList.Clear();
        //Change GeneratePoint position when it's changed
        Pposition = GeneratePoint.transform.position;
        int way = Random.Range(0, 4);
        // 0 = Up , 1 = Bottom , 2 = Left , 3 = Right
        switch (way)
        {
            case 0:
                Debug.Log("Up");
                PathList.Add(0,Instantiate(Path, new Vector3(Pposition.x, Pposition.y, Pposition.z + 8), Quaternion.identity));
                PathList.Add(1,Instantiate(Minus, new Vector3(Pposition.x, Pposition.y, Pposition.z - 8), Quaternion.identity));
                PathList.Add(2,Instantiate(Minus, new Vector3(Pposition.x - 8, Pposition.y, Pposition.z), Quaternion.identity));
                PathList.Add(3,Instantiate(Minus, new Vector3(Pposition.x + 8, Pposition.y, Pposition.z), Quaternion.identity));
                break;
            case 1:
                Debug.Log("Bottom");
                PathList.Add(0, Instantiate(Minus, new Vector3(Pposition.x, Pposition.y, Pposition.z + 8), Quaternion.identity));
                PathList.Add(1, Instantiate(Path, new Vector3(Pposition.x, Pposition.y, Pposition.z - 8), Quaternion.identity));
                PathList.Add(2, Instantiate(Minus, new Vector3(Pposition.x - 8, Pposition.y, Pposition.z), Quaternion.identity));
                PathList.Add(3, Instantiate(Minus, new Vector3(Pposition.x + 8, Pposition.y, Pposition.z), Quaternion.identity));
                break;
            case 2:
                Debug.Log("Left");
                PathList.Add(0, Instantiate(Minus, new Vector3(Pposition.x, Pposition.y, Pposition.z + 8), Quaternion.identity));
                PathList.Add(1, Instantiate(Minus, new Vector3(Pposition.x, Pposition.y, Pposition.z - 8), Quaternion.identity));
                PathList.Add(2, Instantiate(Path, new Vector3(Pposition.x - 8, Pposition.y, Pposition.z), Quaternion.identity));
                PathList.Add(3, Instantiate(Minus, new Vector3(Pposition.x + 8, Pposition.y, Pposition.z), Quaternion.identity));
                break;
            case 3:
                Debug.Log("Right");
                PathList.Add(0, Instantiate(Minus, new Vector3(Pposition.x, Pposition.y, Pposition.z + 8), Quaternion.identity));
                PathList.Add(1, Instantiate(Minus, new Vector3(Pposition.x, Pposition.y, Pposition.z - 8), Quaternion.identity));
                PathList.Add(2, Instantiate(Minus, new Vector3(Pposition.x - 8, Pposition.y, Pposition.z), Quaternion.identity));
                PathList.Add(3, Instantiate(Path, new Vector3(Pposition.x + 8, Pposition.y, Pposition.z), Quaternion.identity));
                break;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Path")
        {
            Debug.Log("Path Exists");
            Score++;
            audiosource.PlayOneShot(RightWay);
            for (int i = 0;i < 4 ;i++)
            {
                Destroy(PathList[i].gameObject);
            }
            GeneratePath();
        }
        if (collision.gameObject.tag == "Minus")
        {
            Debug.Log("Minus Exists");
            audiosource.PlayOneShot(WrongWay);
            for (int i = 0; i < 4; i++)
            {
                Destroy(PathList[i].gameObject);
            }
            GeneratePath();
        }
    }
}