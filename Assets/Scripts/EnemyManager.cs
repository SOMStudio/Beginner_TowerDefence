using System;
using UnityEngine;
using UnityEngine.Events;

public class EnemyManager : MonoBehaviour
{
    [Header("Main")]
    public int health = 1;
    
    [Header("Components")]
    [SerializeField] private MovePointComponent movePointComponent;
    [SerializeField] private TriggerComponent triggerComponent;
    [SerializeField] private DestroyComponent destroyComponent;

    [Header("Events")]
    public UnityEvent<EnemyManager> reachFinalPointEvent;
    public UnityEvent<EnemyManager> deathEvent;

    private void Awake()
    {
        if (movePointComponent == null) movePointComponent = GetComponent<MovePointComponent>();
        if (triggerComponent == null) triggerComponent = GetComponent<TriggerComponent>();
        if (destroyComponent == null) destroyComponent = GetComponent<DestroyComponent>();
    }

    private void Start()
    {
        movePointComponent.finalPointEvent.AddListener(ReachToFinalPoint);
    }

    public void AddHealth(int changeHealth)
    {
        health += changeHealth;
        
        if (health <= 0)
        {
            deathEvent?.Invoke(this);
            
            destroyComponent.DestroyGameObject();
        }
    }

    public void SetPoints(Transform[] points)
    {
        movePointComponent.points = points;
        movePointComponent.Run(true);
    }
    
    public void TriggerWithObject(Collider other)
    {
        AddHealth(-1);
    }

    private void ReachToFinalPoint()
    {
        reachFinalPointEvent?.Invoke(this);
        
        destroyComponent.DestroyGameObject();
    }
}
