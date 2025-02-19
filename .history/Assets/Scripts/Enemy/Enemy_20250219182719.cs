using System.Diagnostics;
using StarterAssets;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject DestoryVFX;
    [SerializeField] Animator HitAnim;
    [SerializeField] int HP = 30;

    GameObject Target;
    NavMeshAgent agent;
    string HIT_String = "Hit";

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
        if(!Target || !agent) return;
        agent.SetDestination(Target.transform.position);
    }

    public void TakeDamage(int DamageAmount)
    {
        if(HitAnim) HitAnim.Play(HIT_String, 0, 0.0f);

        HP -= DamageAmount;

        if(HP <= 0) 
        {
            Destroy(this.gameObject);
            Instantiate(DestoryVFX, transform.position + new Vector3(0.0f, 1.0f, 0.0f), Quaternion.identity);
        }
    }
}
