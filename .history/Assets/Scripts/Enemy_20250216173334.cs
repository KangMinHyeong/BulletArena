using System.Diagnostics;
using StarterAssets;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject Target;
    [SerializeField] int HP;

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

    public void TakeDamage(int DamageAmount)
    {
        HP -= DamageAmount;

        if(HP <= 0) Destroy(this.gameObject);
    }
}
