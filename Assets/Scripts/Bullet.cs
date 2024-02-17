using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public LevelController levelController;
    
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
        } else if (other.gameObject.tag == "Level1")
        {
            levelController.Level1();
            Destroy(gameObject);
        } else if (other.gameObject.tag == "Level2")
        {
            levelController.Level2();
            Destroy(gameObject);
        } else if (other.gameObject.tag == "Level3")
        {
            levelController.Level3();
            Destroy(gameObject);
        }
    }
}
