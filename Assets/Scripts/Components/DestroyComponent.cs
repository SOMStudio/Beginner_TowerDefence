using UnityEngine;
using UnityEngine.Events;

public class DestroyComponent : MonoBehaviour
{
    public bool useDestroyAfterTime;
    public float destroyAfterTime = 5f;

    [Header("Events")]
    public UnityEvent<GameObject> destroyEvent;
    
    private void Start()
    {
        if (useDestroyAfterTime)
        {
            Invoke(nameof(DestroyGameObject), destroyAfterTime);
        }
    }

    public void DestroyGameObject()
    {
        destroyEvent?.Invoke(gameObject);
        
        Destroy(gameObject);
    }
}
