using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MathProblems", menuName = "Kill Them With Maths/MathProblems/Elemntary Schull", order = 0)]
public class MathProblems : ScriptableObject 
{
    public String problemToSolve;
    public List<int> options;
    public int correctOption;
}
