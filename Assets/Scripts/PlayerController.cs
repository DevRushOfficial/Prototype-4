using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _speedRolling = 5.0f;
    private Rigidbody _playerRb;
    private GameObject _focalPoint;

    private void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        _focalPoint = GameObject.Find("Focal Point");
    }

    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");

        _playerRb.AddForce(_focalPoint.transform.forward * forwardInput * _speedRolling);
    }
}
