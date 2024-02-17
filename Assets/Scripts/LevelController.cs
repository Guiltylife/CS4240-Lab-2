using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelController : MonoBehaviour
{
    [SerializeField]
    GameObject flowerpotPrefab;

    public List<GameObject> flowerpots;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Level1()
    {
        ClearAll();

        flowerpots.Add(Instantiate(flowerpotPrefab, new Vector3(0, 0, 1), Quaternion.Euler(0, 0, 0)));
        flowerpots.Add(Instantiate(flowerpotPrefab, new Vector3(-1, 0, 2), Quaternion.Euler(0, 0, 0)));
        flowerpots.Add(Instantiate(flowerpotPrefab, new Vector3(1, 0, 3), Quaternion.Euler(0, 0, 0)));
    }

    public void Level2()
    {
        ClearAll();

        flowerpots.Add(Instantiate(flowerpotPrefab, new Vector3(0, 0, 1), Quaternion.Euler(0, 0, 0)));
        flowerpots.Add(Instantiate(flowerpotPrefab, new Vector3(-1, 0, 2), Quaternion.Euler(0, 0, 0)));
        flowerpots.Add(Instantiate(flowerpotPrefab, new Vector3(1, 0, 3), Quaternion.Euler(0, 0, 0)));

        bool mirror = false;
        foreach (GameObject flowerpot in flowerpots)
        {
            Animator flowerpotAnimator = flowerpot.transform.Find("Flowerpot").GetComponent<Animator>();
            flowerpotAnimator.SetTrigger("Movable");
            flowerpotAnimator.SetBool("Mirror", mirror);
            mirror = !mirror;
        }
    }

    public void Level3()
    {
        ClearAll();


    }

    public void ClearAll()
    {
        foreach (GameObject flowerpot in flowerpots)
        {
            Destroy(flowerpot);
        }
        flowerpots.Clear();
    }
}
