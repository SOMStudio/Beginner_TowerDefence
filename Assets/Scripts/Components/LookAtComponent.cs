using UnityEngine;
using UnityEngine.Events;

public class LookAtComponent : MonoBehaviour
{
    [Header("Main")]
    public Transform target;
    public float speedRotate = 1f;
    public float limitRotate = 5f;

    [Header("Events")]
    public UnityEvent limitRotateEvent;

    private Quaternion startRotate;
    private bool runUpdate;

    private Vector3 vectorToTarget = Vector3.zero;

    public Vector3 VectorToTarget => vectorToTarget;

    private Color colorForHelpRay = Color.yellow;
    
    private void Start()
    {
        startRotate = transform.rotation;
    }

    public void Run(bool setState)
    {
        runUpdate = setState;
    }

    private void Update()
    {
        if (!runUpdate) return;

        Debug.DrawRay(transform.position, transform.forward * 5, Color.black);
        Debug.DrawRay(transform.position, -transform.forward * 5, Color.black);
        Debug.DrawRay(transform.position, transform.right * 5, Color.black);
        Debug.DrawRay(transform.position, -transform.right * 5, Color.black);

        var targetRotate = startRotate;

        if (target == null) return;

        Debug.DrawRay(transform.position, vectorToTarget, colorForHelpRay);
        
        vectorToTarget = GetVectorToTarget(target);
        targetRotate = Quaternion.LookRotation(vectorToTarget);

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotate, Time.deltaTime * speedRotate);

        var angleTargetRotate = Mathf.Abs(Quaternion.Angle(transform.rotation, targetRotate));

        if (angleTargetRotate <= limitRotate)
        {
            limitRotateEvent?.Invoke();
        }
    }

    public Vector3 GetVectorToTarget(Transform targetObj)
    {
        Vector3 targetWithoutYShift = new Vector3(targetObj.position.x, transform.position.y, targetObj.position.z);
        return targetWithoutYShift - transform.position;
    }

    public void SetHelpRayColor(Color setColor)
    {
        colorForHelpRay = setColor;
    }
}
