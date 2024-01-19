using UnityEngine;
using UnityEngine.Events;

public class TimerComponent : MonoBehaviour
{
    public float invokeSecond = 5f;

    [Header("Events")]
    public UnityEvent invokeSecondEvent;

    private void Start()
    {
        Invoke(nameof(InvokeEvent), invokeSecond);
    }

    private void InvokeEvent()
    {
        invokeSecondEvent?.Invoke();
        
        Invoke(nameof(InvokeEvent), invokeSecond);
    }
}
