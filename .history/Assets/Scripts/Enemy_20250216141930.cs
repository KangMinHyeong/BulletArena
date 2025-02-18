using System.Diagnostics;
using StarterAssets;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject Target;

    NavMeshAgent agent;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        Target = FindFirstObjectByType<FirstPersonController>().GameObject();
    }

    void Update()
    {
        Trace();
    }

    void Trace()
    {
        agent.SetDestination(Target.transform.position);
    }
}
