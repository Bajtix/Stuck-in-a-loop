using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneRotation : MonoBehaviour
{
    public float destRot;
    public float rotSpeed = 5f;

    private Rigidbody2D planeRB;

    private void Start()
    {
        planeRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float wingForce = transform.rotation.eulerAngles.z  <= 180 ? - (transform.rotation.eulerAngles.z - 90) : -(transform.rotation.eulerAngles.z - 270);
        Debug.Log(wingForce);
        planeRB.AddRelativeForce(new Vector2(Time.deltaTime * 1000000,Mathf.Abs( wingForce * Time.deltaTime * 10000)));
        destRot += Time.deltaTime * rotSpeed;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, destRot), Time.deltaTime * 2);    
    }
}
