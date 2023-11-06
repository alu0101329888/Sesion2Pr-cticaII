using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPointer : MonoBehaviour
{
    public float horizontalSensitivity;
    public float verticalSensitivity;

    float yaw = 0.0f;
    float pitch = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        yaw += horizontalSensitivity * Input.GetAxis("Mouse X");
        pitch -= verticalSensitivity * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
        {
            // GameObject detected in front of the camera.
            if (hit.transform.gameObject.tag == "Spider")
            {
                hit.transform.gameObject.SendMessage("OnPointerEnter");
            }

            if (hit.transform.gameObject.name == "spiderA")
            {
                GameObject spiderB = GameObject.Find("spiderB");
                GameObject spiderC = GameObject.Find("spiderC");
                GameObject spiderA = GameObject.Find("spiderA");

                GameObject[] beds = GameObject.FindGameObjectsWithTag("Bed");

                spiderB.GetComponent<Rigidbody>().transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);

                Vector3 pos1 = new Vector3(beds[0].transform.position.x, beds[0].transform.position.y + 1, beds[0].transform.position.z);
                Vector3 pos2 = new Vector3(beds[1].transform.position.x, beds[1].transform.position.y + 1, beds[1].transform.position.z);

                spiderA.GetComponent<Rigidbody>().transform.position = pos1;
                spiderC.GetComponent<Rigidbody>().MovePosition(pos2);
            }
        }
    }
}
