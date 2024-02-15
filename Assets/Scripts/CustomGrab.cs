using UnityEngine;

public class CustomGrab : MonoBehaviour
{
    public OVRInput.Controller Controller;

    public string grabButtonName;
    public float grabRadius;
    public LayerMask grabMask;

    private GameObject currGrabbedObject;
    private bool isGrabbing;

    // Update is called once per frame
    void Update()
    {
        // if you hold button
        if (!isGrabbing && Input.GetAxis(grabButtonName) == 1)
        {
            GrabObject();
        }

        // if you let go of button
        if (isGrabbing && Input.GetAxis(grabButtonName) < 1)
        {
            DropObject();
        }
    }

    // For debugging
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, grabRadius);
    }

    void GrabObject()
    {
        RaycastHit hit;

        if (Physics.SphereCast(transform.position, grabRadius, transform.forward, out hit, 100.0f, grabMask))
        {
            isGrabbing = true;

            currGrabbedObject = hit.transform.gameObject; // grab the closest object
            currGrabbedObject.GetComponent<Rigidbody>().isKinematic = true; // the grabbed object should not have gravity

            // grab object will follow our hands
            currGrabbedObject.transform.position = transform.position; 
            currGrabbedObject.transform.parent = transform;
        }
    }

    void DropObject()
    {
        isGrabbing = false;

        // we are currently grabbing something, let it go
        if (currGrabbedObject != null)
        {
            currGrabbedObject.transform.parent = null;
            currGrabbedObject.GetComponent<Rigidbody>().isKinematic = false; // enable gravity again for the object

            /**
             * Throw the object based on how hard we 'swing' our hand
             * 
             * HINT FOR ASSIGNMENT 2: 
             * if you would like to change to shooting instead of throwing, you can use rigidbody AddForce
             * AddForce() requires a direction vector (what direction the object should move towards), there is a way to get what direction this object is pointing towards, can you find it?
             */
            currGrabbedObject.GetComponent<Rigidbody>().velocity = OVRInput.GetLocalControllerVelocity(Controller);
            currGrabbedObject.GetComponent<Rigidbody>().angularVelocity = OVRInput.GetLocalControllerAngularVelocity(Controller);

            currGrabbedObject = null;
        }
    }
}
