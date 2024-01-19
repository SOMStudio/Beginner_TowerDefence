using UnityEngine;
using UnityEngine.Events;

public class MovePointComponent : MonoBehaviour
{
    [Header("Main")]
    public float speed;
    public Transform[] points;

    [Header("Events")]
    public UnityEvent finalPointEvent;

    private int moveToPoint;
    private bool runUpdate;
    
    public void Run(bool setState)
    {
        runUpdate = setState;
    }

    private void Update()
    {
        if (!runUpdate) return;

        Vector3 moveDirection = points[moveToPoint].position - transform.position;
        transform.position += moveDirection.normalized * (Time.deltaTime * speed);

        if (moveDirection.magnitude < 0.01f)
        {
            moveToPoint++;
            
            if (moveToPoint >= points.Length)
            {
                Run(false);
                finalPointEvent?.Invoke();
            }
        }
    }
}
