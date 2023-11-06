using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderA : MonoBehaviour
{
    GameObject chair;
    GameObject table;
    bool state = false;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        chair = GameObject.FindGameObjectWithTag("Chair");
        table = GameObject.FindGameObjectWithTag("Table");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (state)
        {
            // Move towards chair
            Vector3 movement = chair.transform.position - GetComponent<Rigidbody>().transform.position;
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().transform.position + movement.normalized * speed);
        }
        else
        {
            // Move towards table
            Vector3 movement = table.transform.position - GetComponent<Rigidbody>().transform.position;
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().transform.position + movement.normalized * speed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (state && collision.collider.tag == "Chair")
        {
            state = !state;
        }

        if (!state && collision.collider.tag == "Table")
        {
            state = !state;
        }
    }
}
