using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerPot : MonoBehaviour
{
    Rigidbody rb;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            animator.SetTrigger("ProjectileHit");

            Destroy(other.gameObject);
            Destroy(gameObject, 2.0f);
        }
    }
    
}
