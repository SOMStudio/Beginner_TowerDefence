using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    [Header("Main")]
    public int health = 1;
    
    [Header("Components")]
    [SerializeField] private MovePointComponent movePointComponent;
    [SerializeField] private TriggerComponent triggerComponent;
    [SerializeField] private DestroyComponent destroyComponent;
    [SerializeField] private Slider healthSlider;

    [Header("Events")]
    public UnityEvent<EnemyManager> reachFinalPointEvent;
    public UnityEvent<int> helthChangeEvent;
    public UnityEvent<EnemyManager> deathEvent;

    private bool initedState;
    
    private void Awake()
    {
        InitComponents();
    }

    private void Start()
    {
        InitState();
    }

    private void InitComponents()
    {
        if (movePointComponent == null) movePointComponent = GetComponent<MovePointComponent>();
        if (triggerComponent == null) triggerComponent = GetComponent<TriggerComponent>();
        if (destroyComponent == null) destroyComponent = GetComponent<DestroyComponent>();
    }

    private void InitState()
    {
        if (movePointComponent == null) movePointComponent = gameObject.AddComponent<MovePointComponent>();
        if (triggerComponent == null) triggerComponent = gameObject.AddComponent<TriggerComponent>();
        if (destroyComponent == null) destroyComponent = gameObject.AddComponent<DestroyComponent>();

        if (movePointComponent.finalPointEvent == null) movePointComponent.finalPointEvent = new UnityEvent();
        if (triggerComponent.onTriggerEnterEvent == null) triggerComponent.onTriggerEnterEvent = new UnityEvent<Collider>();

        if (!initedState)
        {
            initedState = true;
            
            movePointComponent.speed = 0.5f;
            movePointComponent.finalPointEvent.AddListener(ReachToFinalPoint);

            triggerComponent.onTriggerEnterEvent.AddListener(TriggerWithObject);
        }
    }

    private void AddHealth(int changeHealth)
    {
        health += changeHealth;

        helthChangeEvent.Invoke(health);

        if (health <= 0)
        {
            deathEvent?.Invoke(this);
            
            destroyComponent.DestroyGameObject();
        }
    }

    public void SetPoints(Transform[] points)
    {
        if (movePointComponent == null)
        {
            InitComponents();
            InitState();
        }
        
        movePointComponent.points = points;
        movePointComponent.Run(true);
    }

    private void TriggerWithObject(Collider other)
    {
        AddHealth(-1);
    }

    private void ReachToFinalPoint()
    {
        reachFinalPointEvent?.Invoke(this);
        
        destroyComponent.DestroyGameObject();
    }

    public void ChangeHelth(int health)
    {
        healthSlider.value = health;
    }
}
