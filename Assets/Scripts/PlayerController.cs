using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _speedRolling = 5.0f;
    private Rigidbody _playerRb;

    private void Start() => _playerRb = GetComponent<Rigidbody>();

    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");

        _playerRb.AddForce(Vector3.forward * forwardInput * _speedRolling);
    }
}
