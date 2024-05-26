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
            Plane[] p = GeometryUtility.CalculateFrustumPlanes(Matrix4x4.TRS(transform.position,transform.rotation,transform.localScale));
            if (Vector3.Distance(transform.position, player.position) <= 15 && GeometryUtility.TestPlanesAABB(p, player.gameObject.GetComponent<MeshRenderer>().bounds))
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
