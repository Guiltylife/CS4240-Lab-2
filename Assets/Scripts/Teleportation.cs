using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    [SerializeField]
    Transform player;
    [SerializeField]
    string teleportButtonName;

    bool isHold = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isHold && Input.GetAxis(teleportButtonName) == 1)
        {
            isHold = true;
            Teleport();
        }
        if (Input.GetAxis(teleportButtonName) < 0.1)
        {
            isHold = false;
        }
    }

    void Teleport()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 100.0f))
        {
            GameObject gameObject = hit.collider.gameObject;
            if (gameObject.CompareTag("Floor"))
            {
                Vector3 targetPosition = hit.point;
                targetPosition.y = 0;
                player.position = targetPosition;
            }
        }
    }
}
