using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Flowerpot")
        {
            other.gameObject.GetComponent<Animator>().SetTrigger("ProjectileHit");

            Destroy(gameObject);
            Destroy(other.gameObject, 2.0f);
        }
    }
}
