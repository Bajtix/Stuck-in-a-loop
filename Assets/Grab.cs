using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    public Rigidbody grabbedBody;

    public Transform destinationPoint;

    public float forceM = 1000f;

    public void GrabObject(Rigidbody obj)
    {
        UnGrab();

        grabbedBody = obj;
    }

    public void UnGrab()
    {
        if (grabbedBody == null) return;

        grabbedBody.drag = 0;
        grabbedBody = null;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            if (grabbedBody != null)
            {
                grabbedBody.AddForce(Camera.main.transform.forward * forceM);
                UnGrab();
                return;
            }
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if (grabbedBody != null)
            {
                UnGrab();
                return;
            }

            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 5f))
            {
                if(hit.collider.GetComponent<Rigidbody>() != null)
                {
                    GrabObject(hit.collider.GetComponent<Rigidbody>());
                }
            }
        }
        if (grabbedBody == null) return;
        grabbedBody.AddForce((destinationPoint.position - grabbedBody.transform.position) * Time.deltaTime * forceM);
        grabbedBody.drag = Mathf.Clamp(4f - Vector3.Distance(destinationPoint.position, grabbedBody.transform.position),0,5);

        if (Vector3.Distance(destinationPoint.position, grabbedBody.transform.position) > 5f)
            UnGrab();
    }
}
