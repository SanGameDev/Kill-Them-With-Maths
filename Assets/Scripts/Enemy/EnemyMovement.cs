using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    
    public int numberOfRays = 15;
    public float maxAngle = 90f;
    public float maxDistance = 35f;
    public float moveRange = 10f;
    public GeneralPlayer generalPlayer;
    [HideInInspector]public bool playerSpottedCheked;

    bool startPatrolling;
    Vector3 playerPosition;
    Vector3 lastPositionOfPlayer;
    bool[] playerSpotted = new bool[15];

    void Update()
    {
        playerSpottedCheked = CheckIfAnyTrue(playerSpotted);

        if(playerSpottedCheked)
        {
            agent.SetDestination(playerPosition);
            generalPlayer.SetTagToDueling();
            startPatrolling = false;
        }
        else if(!playerSpottedCheked && !startPatrolling)
        {
            agent.SetDestination(lastPositionOfPlayer);
            generalPlayer.SetTagBackToPlayer();
        }

        if(!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            startPatrolling = true;
            MoveToRandomPoint();
        }
    }

    void FixedUpdate() 
    {
        EmitRays();
    }

    private void EmitRays()
    {
        float startAngle = -maxAngle / 2f;

        for (int i = 0; i < numberOfRays; i++)
        {
            float angle = startAngle + i * (maxAngle / (numberOfRays - 1));

            Vector3 direction = Quaternion.Euler(0f, angle, 0f) * transform.forward;
            RaycastHit hit;

            Debug.DrawRay(transform.position, direction * maxDistance, Color.green, 0.5f);

            if (Physics.Raycast(transform.position, direction, out hit, maxDistance))
            {
                if(hit.collider.gameObject.tag == "Player")
                {
                    playerPosition = hit.collider.gameObject.transform.position;
                    lastPositionOfPlayer = new Vector3(playerPosition.x, transform.position.y, playerPosition.z);
                    playerSpotted[i] = true;
                }
            }
            else
            {
                playerSpotted[i] = false;
            }
        }
    }

    private void MoveToRandomPoint()
    {
        Vector3 randomPosition = Random.insideUnitSphere * moveRange;
        randomPosition += transform.position;
        NavMeshHit hit;

        if (NavMesh.SamplePosition(randomPosition, out hit, moveRange, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }
    }

    bool CheckIfAnyTrue(bool[] array)
    {
        foreach (bool value in array)
        {
            if (value)
            {
                return true;
            }
        }
        return false;
    }

}
