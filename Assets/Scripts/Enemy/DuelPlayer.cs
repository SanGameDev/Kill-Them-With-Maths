using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DuelPlayer : MonoBehaviour
{
    public float distanceToDuel;
    public LayerMask playerMask;
    public Transform player;
    public EnemyMovement enemyMovement;

    bool checkIfDuel;

    void Update()
    {
        checkIfDuel = Physics.CheckSphere(transform.position, distanceToDuel, playerMask);

        if(checkIfDuel)
        {
            Vector3 directionToTarget = player.position - transform.position;

            RaycastHit hit;

            if (Physics.Raycast(transform.position, directionToTarget, out hit))
            {
                if (hit.transform == player && enemyMovement.playerSpottedCheked)
                {
                    
                }
                else
                {
                    
                }
            }
        }
    }
}
