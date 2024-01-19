using UnityEngine;
using UnityEngine.Events;

public class OnMouseComponent : MonoBehaviour
{
    [Header("Events")]
    public UnityEvent onMouseDownEvent;
    public UnityEvent onMouseOverEvent;
    public UnityEvent onMouseUpEvent;
    
    private void OnMouseDown()
    {
        onMouseDownEvent?.Invoke();
    }

    private void OnMouseOver()
    {
        onMouseOverEvent?.Invoke();
    }

    private void OnMouseUp()
    {
        onMouseUpEvent?.Invoke();
    }
}
