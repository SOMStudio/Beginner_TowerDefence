using UnityEngine;
using UnityEngine.Events;

public class TriggerComponent : MonoBehaviour
{
    [Header("Main")]
    public bool checkTag;
    public string nameCheckTag;
    
    [Header("Events")]
    public UnityEvent<Collider> onTriggerEnterEvent;
    public UnityEvent<Collider> onTriggerStayEvent;
    public UnityEvent<Collider> onTriggerExitEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (checkTag && !other.CompareTag(nameCheckTag)) return;
        
        onTriggerEnterEvent?.Invoke(other);
    }

    private void OnTriggerStay(Collider other)
    {
        if (checkTag && !other.CompareTag(nameCheckTag)) return;
        
        onTriggerStayEvent?.Invoke(other);
    }

    private void OnTriggerExit(Collider other)
    {
        if (checkTag && !other.CompareTag(nameCheckTag)) return;
        
        onTriggerExitEvent?.Invoke(other);
    }
}
