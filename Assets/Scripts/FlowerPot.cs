using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerPot : MonoBehaviour
{
    [SerializeField] Animator animator;
    public LevelController levelController;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShootPot()
    {
        animator.enabled = false;
        Invoke("DelayShootPot", 1.0f);
        Destroy(transform.parent.gameObject, 1.0f);
    }

    private void DelayShootPot()
    {
        levelController.ShootPot();
    }
}
