using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _speedRolling = 5.0f;
    private Rigidbody _playerRb;
    private GameObject _focalPoint;

    private bool _hasPowerUp;

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            _hasPowerUp = true;
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && _hasPowerUp)
        {
            Debug.Log("PowerUp was taken");
        }
    }
}