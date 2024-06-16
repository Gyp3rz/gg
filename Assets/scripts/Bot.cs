using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bot : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform[] points;
    private Vector3 lastPos;
    public bool hostile;
    private bool cautious;
    private int point;

    private void Start()
    {
        agent.destination = points[0].position;
    }
    void Update()
    {
        if (cautious)
        {
            if (agent.remainingDistance <= 0.5f)
            {
                cautious = false;
                agent.destination = points[point].position;
            }
        }
        if (hostile)
        {

            if (Vector3.Distance(transform.position, player.position) <= 15 && Vector3.Dot(transform.forward,(player.position-transform.position).normalized)>0.2)
            {
                agent.destination = player.position;
                cautious = true;
                lastPos = player.position;
                return;
            }
            if (cautious)
            {
                agent.destination = lastPos;
                return;
            }
        }
        if (agent.remainingDistance <= 0.1f)
            
        {
            point++;
            if (point >= points.Length)
            {
                point = 0;
            }
            agent.destination = points[point].position;
            Debug.Log(point);
            Debug.Log(agent.remainingDistance);
        }
    }
}
