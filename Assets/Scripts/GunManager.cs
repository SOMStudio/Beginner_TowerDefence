using UnityEngine;
using UnityEngine.Events;

public class GunManager : MonoBehaviour
{
    [Header("Shoot")]
    [SerializeField] private float shootDistance = 10f;

    [Header("Components")]
    [SerializeField] private LookAtComponent lookAtComponent;
    [SerializeField] private SpawnComponent spawnComponent;
    [SerializeField] private TimerComponent timerComponent;

    [Header("events")]
    public UnityEvent<GunManager> needEnemyEvent;

    private bool canShoot = true;
    
    public Vector3 GetVectorToTarget(Transform targetObject)
    {
        return lookAtComponent.GetVectorToTarget(targetObject);
    }
    
    private void Start()
    {
        lookAtComponent.limitRotateEvent.AddListener(CanShoot);

        lookAtComponent.Run(true);
    }

    public void TryShoot()
    {
        if (lookAtComponent.target == null)
        {
            needEnemyEvent?.Invoke(this);
            return;
        }
        
        if (lookAtComponent.VectorToTarget.magnitude <= shootDistance)
        {
            lookAtComponent.SetHelpRayColor(Color.green);
            
            if (canShoot)
            {
                spawnComponent.Spawn();
                
                canShoot = false;
            }
        }
        else
        {
            lookAtComponent.SetHelpRayColor(Color.yellow);

            SetTarget(null);
        }
    }

    private void CanShoot()
    {
        if (!canShoot) canShoot = true;
    }

    public void SetTarget(Transform target)
    {
        lookAtComponent.target = target;
    }
}
