using UnityEngine;

public class MoveComponent : MonoBehaviour
{
    public Vector3 direction = Vector3.forward;
    public float speed = 1f;
    public bool useDirection = true;

    private void Update()
    {
        if (useDirection)
            transform.position += direction * (speed * Time.deltaTime);
        else
            transform.position += transform.forward * (speed * Time.deltaTime);
    }
}
