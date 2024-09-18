using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
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
        Vector3 playerDirection = _player.transform.position - transform.position;
        _enemyRb.AddForce(playerDirection.normalized * _speed);            
    }
}