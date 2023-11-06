using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedBehaviour : MonoBehaviour
{
    public delegate void message();
    public event message OnBedCollision;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "FilledBed")
        {
            OnBedCollision();
        }
    }
}
