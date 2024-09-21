using UnityEngine;

public class EnemyChaser : MonoBehaviour
{
    private const float Bounds = -14f;
    private float _speed = 1.0f;
    private Rigidbody _enemyRb;
    private GameObject _player;

    void Start()
    {
        _enemyRb = GetComponent<Rigidbody>();
        _player = GameObject.Find("Player");
    }

    void Update()
    {
        DestroyOutOfBounds();
        ChasePlayer();
    }

    private void ChasePlayer()
    {
        Vector3 playerDirection = _player.transform.position - transform.position;
        _enemyRb.AddForce(playerDirection.normalized * _speed);
    }

    private void DestroyOutOfBounds()
    {
        if(transform.position.y < Bounds)
        {
            Destroy(gameObject);
        }
    }
}