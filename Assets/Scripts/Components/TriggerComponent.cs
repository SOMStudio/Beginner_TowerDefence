using UnityEngine;
using UnityEngine.Events;

public class TriggerComponent : MonoBehaviour
{
    public UnityEvent<Collider> onTriggerEnterEvent;
    public UnityEvent<Collider> onTriggerStayEvent;
    public UnityEvent<Collider> onTriggerExitEvent;

    private void OnTriggerEnter(Collider other)
    {
        onTriggerEnterEvent?.Invoke(other);
    }

    private void OnTriggerStay(Collider other)
    {
        onTriggerStayEvent?.Invoke(other);
    }

    private void OnTriggerExit(Collider other)
    {
        onTriggerExitEvent?.Invoke(other);
    }
}
