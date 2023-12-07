using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTrigger : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _currentSpeed;
    private FinishTrigger _finishTrigger;

    private void Start()
    {
        _finishTrigger = FindObjectOfType<FinishTrigger>();
    }

    private void FixedUpdate()
    {
        Move();
        if (gameObject.transform.position.y > -10f)
        {
         //   _finishTrigger.TakeAwayBall();
         //   Destroy(gameObject);
            Debug.Log("удаоен");
        }
    }
    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.TryGetComponent<Wall>(out Wall wallComponent))
        {
            _rigidbody.AddForce(Vector3.zero);
            _rigidbody.velocity = Vector3.zero;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.TryGetComponent<Wall>(out Wall wallComponent) || collider.gameObject.TryGetComponent<BallTrigger>(out BallTrigger ballTriggerComponent))
        {
            _rigidbody.AddForce(Vector3.zero);
            _rigidbody.velocity = Vector3.zero;
        }
      
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.TryGetComponent<Wall>(out Wall wallComponent) || collider.gameObject.TryGetComponent<BallTrigger>(out BallTrigger ballTriggerComponent))
        {
            Move();
        }
    }

    private void Move()
    {
        _rigidbody.AddForce(0, 0, -1 * _speed);
    }

    public void MinusFallenBall()
    {

    }
}
