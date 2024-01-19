using UnityEngine;
using UnityEngine.Events;

public class SpawnComponent : MonoBehaviour
{
    public GameObject spawnObject;
    public Transform spawnPosition;

    [Header("Events")]
    public UnityEvent<GameObject> spawnObjectEvent;

    public void Spawn()
    {
         GameObject spawnObj = Instantiate(spawnObject, spawnPosition.position, spawnPosition.rotation);
         
         spawnObjectEvent?.Invoke(spawnObj);
    }
}
