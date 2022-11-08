using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartController : MonoBehaviour
{
    float rotationAngle = 0.7f;

    public float MoveSpeed = 5.0f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("a"))
        {
            this.transform.RotateAround(this.transform.position, Vector3.up, -rotationAngle);
        }
        else if (Input.GetKey("d"))
        {
            this.transform.RotateAround(this.transform.position, Vector3.up, rotationAngle);
        }

        if (Input.GetKey("w"))
        {
            this.GetComponent<Rigidbody>().velocity = this.transform.forward * 6.0f;
        }

        if (Input.GetKey("s"))
        {
            this.GetComponent<Rigidbody>().velocity = -this.transform.forward * 3.0f;
        }

    }
}
