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
        startPoint = transform.position;
        endPoint = startPoint; endPoint.y += 2f;
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
