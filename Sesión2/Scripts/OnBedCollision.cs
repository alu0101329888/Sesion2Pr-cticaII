using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBedCollision : MonoBehaviour
{
    public BedBehaviour player;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        player.OnBedCollision += Reaction;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void Reaction()
    {
        if (tag == "Chair")
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up.normalized * speed, ForceMode.Impulse);
        }
        else if (tag == "Bed" || tag == "FilledBed")
        {
            GetComponent<Rigidbody>().AddForce(Vector3.left.normalized * speed, ForceMode.Impulse);
        }
    }
}
