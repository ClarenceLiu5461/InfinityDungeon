using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePath : MonoBehaviour
{
    int Score = 0;
    public GameObject Path;
    public GameObject Minus;
    public GameObject GeneratePoint;
    public AudioClip RightWay;
    public AudioClip WrongWay;
    AudioSource audiosource;

    private Vector3 Pposition; //GeneratePoint's last position
    void Start()
    {
        //Generate the first path
        GeneratePath();
        audiosource = GetComponent<AudioSource>();
    }

    public void GeneratePath()
    {
        //Change GeneratePoint position when it's changed
        Pposition = GeneratePoint.transform.position;
        int way = Random.Range(0, 4);
        // 0 = Up , 1 = Bottom , 2 = Left , 3 = Right
        switch (way)
        {
            case 0:
                Debug.Log("Up");
                Instantiate(Path, new Vector3(Pposition.x, Pposition.y, Pposition.z + 8), Quaternion.identity);
                Instantiate(Minus, new Vector3(Pposition.x, Pposition.y, Pposition.z - 8), Quaternion.identity);
                Instantiate(Minus, new Vector3(Pposition.x - 8, Pposition.y, Pposition.z), Quaternion.identity);
                Instantiate(Minus, new Vector3(Pposition.x + 8, Pposition.y, Pposition.z), Quaternion.identity);
                break;
            case 1:
                Debug.Log("Bottom");
                Instantiate(Minus, new Vector3(Pposition.x, Pposition.y, Pposition.z + 8), Quaternion.identity);
                Instantiate(Path, new Vector3(Pposition.x, Pposition.y, Pposition.z - 8), Quaternion.identity);
                Instantiate(Minus, new Vector3(Pposition.x - 8, Pposition.y, Pposition.z), Quaternion.identity);
                Instantiate(Minus, new Vector3(Pposition.x + 8, Pposition.y, Pposition.z), Quaternion.identity);
                break;
            case 2:
                Debug.Log("Left");
                Instantiate(Minus, new Vector3(Pposition.x, Pposition.y, Pposition.z + 8), Quaternion.identity);
                Instantiate(Minus, new Vector3(Pposition.x, Pposition.y, Pposition.z - 8), Quaternion.identity);
                Instantiate(Path, new Vector3(Pposition.x - 8, Pposition.y, Pposition.z), Quaternion.identity);
                Instantiate(Minus, new Vector3(Pposition.x + 8, Pposition.y, Pposition.z), Quaternion.identity);
                break;
            case 3:
                Debug.Log("Right");
                Instantiate(Minus, new Vector3(Pposition.x, Pposition.y, Pposition.z + 8), Quaternion.identity);
                Instantiate(Minus, new Vector3(Pposition.x, Pposition.y, Pposition.z - 8), Quaternion.identity);
                Instantiate(Minus, new Vector3(Pposition.x - 8, Pposition.y, Pposition.z), Quaternion.identity);
                Instantiate(Path, new Vector3(Pposition.x + 8, Pposition.y, Pposition.z), Quaternion.identity);
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
            Destroy(Path.gameObject);
            Destroy(Minus.gameObject);
            GeneratePath();
        }
        if (collision.gameObject.tag == "Minus")
        {
            Debug.Log("Minus Exists");
            audiosource.PlayOneShot(WrongWay);
            Destroy(Path.gameObject);
            Destroy(Minus.gameObject);
            GeneratePath();
        }
    }
}