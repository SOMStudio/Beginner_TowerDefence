using System;
using UnityEngine;
using UnityEngine.Events;

public class GunBaseManager : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private OnMouseComponent onMouseComponent;
    [SerializeField] private SpawnComponent spawnComponent;
    [SerializeField] private DestroyComponent destroyComponent;

    private void Awake()
    {
        if (onMouseComponent == null) onMouseComponent = GetComponent<OnMouseComponent>();
        if (spawnComponent == null) spawnComponent = GetComponent<SpawnComponent>();
        if (destroyComponent == null) destroyComponent = GetComponent<DestroyComponent>();
    }

    public void SpawnGun()
    {
        spawnComponent.Spawn();
        destroyComponent.DestroyGameObject();
    }
}
