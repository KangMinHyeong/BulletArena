using UnityEngine;

public abstract class PickupBase : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 20.0f;
    [SerializeField] float MoveSpeed = 20.0f;

    string CollisionEnabelTag = "Player";
    Vector3 startPoint;
    Vector3 endPoint;
    
    void Start()
    {
        MoveSpeed = Random.Range(MoveSpeed - 0.1f, MoveSpeed + 0.1f);
        startPoint = transform.position;
        endPoint = startPoint; endPoint.y += .3f;
    }

    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);

        float t = Mathf.PingPong(Time.time * MoveSpeed, 1);
        transform.position = Vector3.Lerp(startPoint, endPoint, t);
    }

    void OnTriggerEnter(Collider other)
    {
        var tag = other.gameObject.tag;

        if (tag != CollisionEnabelTag) return;
        
        Destroy(this.gameObject);

        HandlePickup(other);
    }

    protected abstract void HandlePickup(Collider other);
    
}
