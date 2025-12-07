using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
public class Enemyai : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] NavMeshAgent agent;
    public Transform[] setpoints;

    [SerializeField] float checkinterval;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform furthestpoint = null;
        float furthestdistance = 0f;

        foreach (Transform point in setpoints)
        {
            float DistanceFromPlayer = Vector3.Distance(player.position, point.position);

            if(DistanceFromPlayer > furthestdistance)
            {
                furthestpoint = point;
                furthestdistance = DistanceFromPlayer;
            }
        }

        if (furthestpoint != null)
        {
            agent.SetDestination(furthestpoint.position);
        }

    }
}
