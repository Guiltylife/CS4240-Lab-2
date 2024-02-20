using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    [SerializeField]
    LevelController levelController;
    [SerializeField]
    int level;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel()
    {
        if (level == 0) levelController.Level0();
        else if (level == 1) levelController.Level1();
        else if (level == 2) levelController.Level2();
        else if (level == 3) levelController.Level3();
    }
}
