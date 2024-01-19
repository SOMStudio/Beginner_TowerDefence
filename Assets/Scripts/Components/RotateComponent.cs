using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateComponent : MonoBehaviour
{
    public Vector3 direction = Vector3.up;
    public float speed = 100f;

    private void Update()
    {
        transform.Rotate(direction * (Time.deltaTime * speed));
    }
}
