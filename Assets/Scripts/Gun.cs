using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    string shootButtonName;
    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField]
    Transform gunHead;
    [SerializeField]
    float bulletForce;
    [SerializeField]
    AudioSource shootSound;

    public bool isHold = false;
    
    bool isDown = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isHold && !isDown && Input.GetAxis(shootButtonName) == 1)
        {
            isDown = true;
            GameObject bullet = Instantiate(bulletPrefab, gunHead.position, gunHead.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletForce);

            shootSound.Play();
        }

        if (Input.GetAxis(shootButtonName) < 0.1)
        {
            isDown = false;
        }
    }
}
