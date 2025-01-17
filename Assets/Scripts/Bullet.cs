using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Flowerpot")
        {
            other.GetComponent<FlowerPot>().ShootPot();
            other.transform.Find("Flower").GetComponent<Flower>().Bloom();

            Destroy(gameObject);
        } else if (other.gameObject.tag == "LevelSelector")
        {
            other.GetComponent<LevelSelector>().LoadLevel();

            Destroy(gameObject);
        }
    }
}
