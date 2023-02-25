using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePath : MonoBehaviour
{
    int Score = 0;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void GeneratePath()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Score")
        {
            Score++;
            Destroy(this.gameObject);
        }
    }
}
