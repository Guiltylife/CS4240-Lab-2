using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField]
    Text levelBoard;
    [SerializeField]
    Text scoreBoard;
    [SerializeField]
    Text timeBoard;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLevelBoard(int num)
    {
        levelBoard.text = num.ToString();
    }

    public void SetScoreBoard(int num)
    {
        scoreBoard.text = num.ToString();
    }

    public void SetTimeBoard(int num)
    {
        timeBoard.text = num.ToString();
    }

    public void ClearBoards()
    {
        levelBoard.text = "-";
        scoreBoard.text = "-";
        timeBoard.text = "-";
    }
}
