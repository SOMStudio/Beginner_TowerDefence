using UnityEngine;
using UnityEngine.Events;

public class LookAtComponent : MonoBehaviour
{
    public Transform target;

    [Header("Events")]
    public UnityEvent limitRotateEvent;
    
    private void Update()
    {
        if (target == null) return;

        Vector3 lookAtPosition = new Vector3(target.position.x, transform.position.y, target.position.z);
        transform.LookAt(lookAtPosition);
        
        limitRotateEvent?.Invoke();
    }
}
