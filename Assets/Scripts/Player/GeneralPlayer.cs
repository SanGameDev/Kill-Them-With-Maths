using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class GeneralPlayer : MonoBehaviour
{
    public void SetTagToDueling()
    {
        Debug.Log("lol");
        gameObject.tag = "PlayerDueling";
    }

    public void SetTagBackToPlayer()
    {
        gameObject.tag = "Player";
    }
}
