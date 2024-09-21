using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const float PowerUpDurationSeconds = 7f;
    private bool _hasPowerUp;
    private float _powerUpStrength = 12.0f;
    private float _speedRolling = 5.0f;

    private Rigidbody _playerRb;
    private GameObject _focalPoint;
    [SerializeField]
    private GameObject _powerupIndicator;

    void Start()
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
            ActivatePowerUp(other);
        }
    }

    private void ActivatePowerUp(Collider powerUp)
    {
        _hasPowerUp = true;
        _powerupIndicator.SetActive(true);
        Destroy(powerUp.gameObject);
        StartCoroutine(PowerUpDuration());
    }

    IEnumerator PowerUpDuration()
    {
        yield return new WaitForSeconds(PowerUpDurationSeconds);
        _hasPowerUp = false;
        _powerupIndicator.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && _hasPowerUp)
        {
            ApplyKnockbackToEnemy(collision);
        }
    }

    private void ApplyKnockbackToEnemy(Collision enemy)
    {
        Rigidbody enemyRigidbody = enemy.gameObject.GetComponent<Rigidbody>();
        Vector3 playerDirection = enemy.transform.position - transform.position;
        enemyRigidbody.AddForce(playerDirection * _powerUpStrength, ForceMode.Impulse);

        Debug.Log("PowerUp was used");
    }
}