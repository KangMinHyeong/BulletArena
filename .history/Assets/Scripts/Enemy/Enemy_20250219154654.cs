using System.Diagnostics;
using StarterAssets;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject DestoryVFX;
    [SerializeField] int HP = 30;

    GameObject Target;
    NavMeshAgent agent;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        Target = FindFirstObjectByType<FirstPersonController>().gameObject;
    }

    void Update()
    {
        Trace();
    }

    void Trace()
    {
        if(!Target) return;
        agent.SetDestination(Target.transform.position);
    }

    public void TakeDamage(int DamageAmount)
    {
        HP -= DamageAmount;

        if(HP <= 0) 
        {
            Destroy(this.gameObject);
            Instantiate(DestoryVFX, transform.position + new Vector3(0.0f, 1.0f, 0.0f), Quaternion.identity);
        }
    }
}
