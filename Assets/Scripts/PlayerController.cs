using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _powerUpStrength = 12.0f;
    private float _speedRolling = 5.0f;
    private Rigidbody _playerRb;
    private GameObject _focalPoint;

    [SerializeField]
    private GameObject _powerupIndicator;
    [SerializeField]
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

        _powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            _hasPowerUp = true;
            _powerupIndicator.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerUpDuration());
        }
    }

    IEnumerator PowerUpDuration()
    {
        yield return new WaitForSeconds(7);
        _hasPowerUp = false;
        _powerupIndicator.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && _hasPowerUp)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 playerDirection = collision.transform.position - transform.position;

            enemyRigidbody.AddForce(playerDirection * _powerUpStrength, ForceMode.Impulse);


            Debug.Log("PowerUp was used");
        }
    }
}