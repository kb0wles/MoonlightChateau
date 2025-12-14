using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
public class Enemyai : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] NavMeshAgent agent;

    MeshRenderer rend;
    public Transform[] setpoints;

    [SerializeField] float checkinterval;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rend = GetComponent<MeshRenderer>();
        rend.enabled = false;
        //rend.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(MinigameManger.Instance.getGameStatus())
        {
            agent.isStopped = false;

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
        else agent.isStopped = true;

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            MinigameManger.Instance.Timerdeactivate();
            MinigameManger.Instance.winpopup.SetActive(true);
        }

        if(other.CompareTag("Flashlight"))
        {
            rend.enabled = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Flashlight"))
        {
            rend.enabled = false;
        }
    }

}
