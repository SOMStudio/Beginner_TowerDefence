using UnityEngine;

public class AttachComponent : MonoBehaviour
{
    public Transform parent;
    
    public void Attach()
    {
        transform.parent.SetParent(parent);
    }

    public void Detach()
    {
        transform.parent = null;
    }
}
