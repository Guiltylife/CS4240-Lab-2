using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayControl : MonoBehaviour
{
    [SerializeField]
    Transform startPoint;
    [SerializeField]
    float maxLength;

    private LineRenderer lineRender;
    
    // Start is called before the first frame update
    void Start()
    {
        lineRender = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Vector3 endPosition = new Vector3(0, 0, maxLength);

        if (Physics.Raycast(startPoint.position, transform.forward, out hit, 100.0f))
        {
            endPosition = hit.point;
            Debug.Log(endPosition);
        }

        lineRender.SetPosition(1, endPosition);
    }
}
