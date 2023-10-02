using System.Collections.Generic;
using UnityEngine;
  
[System.Serializable]
public class ListOfProblems
{
  public List<MathProblems> problems;
}
[System.Serializable]
public class ListOfDificulties
{
  public List<ListOfProblems> dificulty;
}