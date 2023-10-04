using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dueling : MonoBehaviour
{
    public ListOfDificulties listOfAddingProblems = new ListOfDificulties();

    public GameObject canvas;
    public TMP_Text problemText;
    public List<Button> buttons;

    int randomDificulty;
    int randomProblem;
    List<int> usedIndices = new List<int>();
    int selectedElement = -1;

    void Start()
    {
        randomDificulty = Random.Range(0, listOfAddingProblems.dificulty.Count - 1);
        randomProblem = Random.Range(0, listOfAddingProblems.dificulty[randomDificulty].problems.Count - 1);
    }

    public void StartingBattle()
    {
        canvas.SetActive(true);
        Time.timeScale = 0.3f;
        problemText.text = listOfAddingProblems.dificulty[randomDificulty].problems[randomProblem].problemToSolve;
        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].GetComponentInChildren<TMP_Text>().text = listOfAddingProblems.dificulty[randomDificulty].problems[randomProblem].options[GetRandomElement()].ToString();            
        }
    }

    int GetRandomElement()
    {
        if (usedIndices.Count >= listOfAddingProblems.dificulty[randomDificulty].problems[randomProblem].options.Count)
        {
            Debug.LogWarning("Todos los elementos han sido seleccionados.");
            return -1;
        }

        int randomIndex;
        do
        {
            randomIndex = Random.Range(0, listOfAddingProblems.dificulty[randomDificulty].problems[randomProblem].options.Count);
        }
        while (usedIndices.Contains(randomIndex));

        usedIndices.Add(randomIndex);
        selectedElement = listOfAddingProblems.dificulty[randomDificulty].problems[randomProblem].options[randomIndex];
        return selectedElement;
    }

    public void ButtomChose1()
    {
        if(buttons[0].GetComponentInChildren<TMP_Text>().text == listOfAddingProblems.dificulty[randomDificulty].problems[randomProblem].correctOption.ToString())
        {
            canvas.SetActive(false);
            Time.timeScale = 1f;
            Destroy(gameObject, 0.5f);
        }
    }

    public void ButtomChose2()
    {
        if(buttons[1].GetComponentInChildren<TMP_Text>().text == listOfAddingProblems.dificulty[randomDificulty].problems[randomProblem].correctOption.ToString())
        {
            canvas.SetActive(false);
            Time.timeScale = 1f;
            Destroy(gameObject, 0.5f);
        }
    }

    public void ButtomChose3()
    {
        if(buttons[2].GetComponentInChildren<TMP_Text>().text == listOfAddingProblems.dificulty[randomDificulty].problems[randomProblem].correctOption.ToString())
        {
            canvas.SetActive(false);
            Time.timeScale = 1f;
            Destroy(gameObject, 0.5f);
        }
    }

    public void ButtomChose4()
    {
        if(buttons[3].GetComponentInChildren<TMP_Text>().text == listOfAddingProblems.dificulty[randomDificulty].problems[randomProblem].correctOption.ToString())
        {
            canvas.SetActive(false);
            Time.timeScale = 1f;
            Destroy(gameObject, 0.5f);
        }
    }
}
