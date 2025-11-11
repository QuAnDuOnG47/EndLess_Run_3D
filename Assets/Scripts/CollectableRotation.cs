using UnityEngine;

public class CollectableRotation : MonoBehaviour
{
    public float rotationSpeed = 1f;
    void Update()
    {
        transform.Rotate(0, rotationSpeed, 0 , Space.World);
    }
}
