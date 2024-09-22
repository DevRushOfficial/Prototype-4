using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject _powerupIndicator;
    private Vector3 _powerUpIndicatorOffset = new Vector3(0, -0.5f, 0);

    private Rigidbody _playerRb;
    private GameObject _focalPoint;
    private float _speedRolling = 5.0f;

    private bool _hasPowerUp;
    public bool HasPowerUp
    {
        get { return _hasPowerUp; }
        set { _hasPowerUp = value; }
    }

    void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        _focalPoint = GameObject.Find("Focal Point");
    }

    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        _playerRb.AddForce(_focalPoint.transform.forward * forwardInput * _speedRolling);
        _powerupIndicator.transform.position = transform.position + _powerUpIndicatorOffset;
    }
}