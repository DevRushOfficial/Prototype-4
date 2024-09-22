using System.Collections;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private GameObject _powerupIndicator;
    private PlayerController _playerController;

    private const float PowerUpDurationSeconds = 7.0f;
    private float _powerUpStrength = 12.0f;

    void Start() => _playerController = GetComponent<PlayerController>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            ActivatePowerUp(other);
        }
    }

    private void ActivatePowerUp(Collider powerUp)
    {
        _playerController.HasPowerUp = true;
        Destroy(powerUp.gameObject);
        _powerupIndicator.SetActive(true);
        StartCoroutine(PowerUpDuratuin());
    }

    IEnumerator PowerUpDuratuin()
    {
        yield return new WaitForSeconds(PowerUpDurationSeconds);
        _playerController.HasPowerUp = false;
        _powerupIndicator.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && _playerController.HasPowerUp)
        {
            ApplyKnockbackToEnemy(collision);
        }
    }

    private void ApplyKnockbackToEnemy(Collision enemy)
    {
        Rigidbody enemyRigidbody = enemy.gameObject.GetComponent<Rigidbody>();
        Vector3 pushDirection = enemy.transform.position - transform.position;

        enemyRigidbody.AddForce(pushDirection * _powerUpStrength, ForceMode.Impulse);
        Debug.Log("PowerUp was used!");
    }
}
