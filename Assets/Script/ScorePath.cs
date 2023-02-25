using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePath : MonoBehaviour
{
    int Score = 0;
    public AudioClip RightWay;
    public AudioClip WrongWay;
    AudioSource audiosource;
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Score")
        {
            Debug.Log("Score Exists");
            Score++;
            audiosource.PlayOneShot(RightWay);
            //Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Minus")
        {
            Debug.Log("Minus Exists");
            audiosource.PlayOneShot(WrongWay);
            //Destroy(collision.gameObject);
        }
    }
}
