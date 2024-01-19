using UnityEngine;
using UnityEngine.Events;

public class MovePointComponent : MonoBehaviour
{
    [Header("Main")]
    public float speed;
    public Transform[] points;
    public bool moveCycle = true;

    [Header("Events")]
    public UnityEvent finalPointEvent;

    private int moveToPoint;

    private void Update()
    {
        Vector3 moveDirection = points[moveToPoint].position - transform.position;
        transform.position += moveDirection.normalized * (Time.deltaTime * speed);

        if (moveDirection.magnitude < 0.01f)
        {
            moveToPoint++;
            
            if (moveToPoint >= points.Length)
            {
                finalPointEvent?.Invoke();

                if (moveCycle) moveToPoint = 0;
                else moveToPoint = points.Length - 1;
            }
        }
    }
}
