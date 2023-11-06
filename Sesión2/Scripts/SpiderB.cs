using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderB : MonoBehaviour
{
    public float horizontalLimitPos = 5f;
    public float horizontalLimitNeg = -2.5f;
    public float verticalLimitPos = 1f;
    public float verticalLimitNeg = -3.5f;

    Vector3 pointA;
    Vector3 pointB;

    bool state = false;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        pointA.x = Random.Range(horizontalLimitNeg, horizontalLimitPos);
        pointA.y = 0;
        pointA.z = Random.Range(verticalLimitNeg, verticalLimitPos);

        pointB.x = Random.Range(horizontalLimitNeg, horizontalLimitPos);
        pointB.y = 0;
        pointB.z = Random.Range(verticalLimitNeg, verticalLimitPos);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (state)
        {
            // Move towards chair
            Vector3 movement = pointA - GetComponent<Rigidbody>().transform.position;
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().transform.position + movement.normalized * speed);

            if (Vector3.Distance(GetComponent<Rigidbody>().transform.position, pointA) <= 1)
            {
                state = !state;
            }
        }
        else
        {
            // Move towards table
            Vector3 movement = pointB - GetComponent<Rigidbody>().transform.position;
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().transform.position + movement.normalized * speed);

            if (Vector3.Distance(GetComponent<Rigidbody>().transform.position, pointB) <= 1)
            {
                state = !state;
            }
        }
    }
}
