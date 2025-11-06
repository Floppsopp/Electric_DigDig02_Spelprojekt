using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EmpyyNavMeshAgent : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;

    public Transform Player;
    void Start()
    {
        if (_agent == null)
        {
            _agent = GetComponent<NavMeshAgent>();
        }
        if (_agent != null)
        {
            _agent.destination = Player.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_agent != null)
        {
            _agent.destination = Player.position;
        }
    }
}
