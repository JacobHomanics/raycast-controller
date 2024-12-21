using UnityEngine;
using UnityEngine.Events;

public class RaycastController : MonoBehaviour
{
    [Header("Configuration")]
    public float distance = Mathf.Infinity;
    public LayerMask layerMask = ~0;

    public bool castOnUpdate = true;

    [Header("Debug")]
    public Color rayColor = Color.red;
    public Color rayHitColor = Color.green;
    public Color sphereColor = Color.blue;
    public float hitSphereSize = 0.25f;

    [Header("Events")]
    public UnityEvent<Collider> OnEnter = new();
    public UnityEvent<Collider> OnStay = new();
    public UnityEvent<Collider> OnExit = new();

    public Collider LastHit { get; private set; }

    private Ray ray;
    private RaycastHit hit;

    void Update()
    {
        if (!castOnUpdate) return;

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, distance, layerMask))
        {
            if (hit.collider != null)
            {
                if (hit.collider != LastHit)
                {
                    if (LastHit != null)
                        OnExit?.Invoke(LastHit);

                    OnEnter?.Invoke(hit.collider);

                    LastHit = hit.collider;
                }
                else
                {
                    OnStay?.Invoke(hit.collider);
                }
            }
            else
            {
                if (LastHit != null)
                {
                    OnExit?.Invoke(LastHit);
                    LastHit = null;
                }
            }
        }
        else
        {
            if (LastHit != null)
            {
                OnExit?.Invoke(LastHit);
                LastHit = null;
            }
        }
    }

    void OnDrawGizmos()
    {
        if (Camera.main == null)
            return;

        float maxDistance = Mathf.Min(distance, 10000f);

        Gizmos.color = rayColor;
        Gizmos.DrawRay(ray.origin, ray.direction * maxDistance);

        // Draw the hit point
        if (hit.collider != null)
        {
            Gizmos.color = rayHitColor;
            Gizmos.DrawLine(ray.origin, hit.point);
            Gizmos.color = sphereColor;
            Gizmos.DrawWireSphere(hit.point, 0.25f); // Sphere size is adjustable
        }
    }
}
