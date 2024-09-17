using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    private float _speedRotation = 50f;

    void Update()
    {
        float _horizontalInput = Input.GetAxis("Horizontal");

        transform.Rotate(Vector3.up, _horizontalInput * _speedRotation * Time.deltaTime);
    }
}
