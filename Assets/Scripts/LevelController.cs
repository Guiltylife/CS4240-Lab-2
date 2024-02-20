using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelController : MonoBehaviour
{
    [SerializeField]
    UIController uiController;
    [SerializeField]
    GameObject flowerpotPrefab;
    [SerializeField]
    GameObject instructionBoard;
    [SerializeField]
    GameObject gameBoard;

    public List<GameObject> flowerpots;

    private int level = 0;
    private int score = 0;
    private int time = 0;

    private int potNum = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Level0()
    {
        ClearAllPots();
        ClearAllBoards();
        ClearAllValue();

        instructionBoard.SetActive(true);

        level = 0;
        score = 0;
        time = 0;
    }

    public void Level1()
    {
        ClearAllPots();
        ClearAllBoards();
        ClearAllValue();

        gameBoard.SetActive(true);

        level = 1;
        score = 0;
        uiController.SetLevelBoard(level);
        uiController.SetScoreBoard(score);

        GeneratePot(new Vector3(0, 0, 1), Quaternion.Euler(0, 0, 0));
        GeneratePot(new Vector3(-1, 0, 2), Quaternion.Euler(0, 0, 0));
        GeneratePot(new Vector3(1, 0, 3), Quaternion.Euler(0, 0, 0));
    }

    public void Level2()
    {
        ClearAllPots();
        ClearAllBoards();
        ClearAllValue();

        gameBoard.SetActive(true);

        level = 2;
        score = 0;
        uiController.SetLevelBoard(level);
        uiController.SetScoreBoard(score);

        GeneratePot(new Vector3(0, 0, 1), Quaternion.Euler(0, 0, 0), true);
        GeneratePot(new Vector3(-1, 0, 2), Quaternion.Euler(0, 0, 0), true);
        GeneratePot(new Vector3(1, 0, 3), Quaternion.Euler(0, 0, 0), true);
    }

    public void Level3()
    {
        ClearAllPots();
        ClearAllBoards();
        ClearAllValue();

        gameBoard.SetActive(true);

        level = 3;
        score = 0;
        time = 60;
        uiController.SetLevelBoard(level);
        uiController.SetScoreBoard(score);
        uiController.SetTimeBoard(time);
    }

    private void ClearAllPots()
    {
        foreach (GameObject flowerpot in flowerpots)
        {
            Destroy(flowerpot);
        }
        flowerpots.Clear();
    }

    private void ClearAllBoards()
    {
        instructionBoard.SetActive(false);
        gameBoard.SetActive(false);
        uiController.ClearBoards();
    }

    private void ClearAllValue()
    {
        level = 0;
        score = 0;
        time = 0;
        potNum = 0;
    }

    public void ShootPot()
    {
        score += 10;
        uiController.SetScoreBoard(score);

        potNum--;
    }

    private void GeneratePot(Vector3 pos, Quaternion angel, bool movable=false)
    {
        GameObject pot = Instantiate(flowerpotPrefab, pos, angel);
        
        potNum++;

        pot.transform.Find("Flowerpot").GetComponent<FlowerPot>().levelController = this;

        if (movable)
        {
            Animator flowerpotAnimator = pot.transform.Find("Flowerpot").GetComponent<Animator>();
            flowerpotAnimator.SetTrigger("Movable");
            flowerpotAnimator.SetBool("Mirror", UnityEngine.Random.Range(0, 2) == 0);
        }

        flowerpots.Add(pot);
    }
}
