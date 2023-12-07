using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _currentSpeed;
    [SerializeField] private bool _movement;
    [SerializeField] private Ball _nextBall;

    private void Start()
    {
        _movement = true;
    }

    private void FixedUpdate()
    {
            StopBehind();      
    }

    private void MoveForward()
    {
        _rigidbody.AddForce(0, 0, -1 * _speed);
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.TryGetComponent<Conncter>(out Conncter connecterComponent))
        {
            _rigidbody.constraints = RigidbodyConstraints.None;
            MoveForward();
            _movement = true;
            Debug.Log("TriggerEnter");
        }
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.TryGetComponent<Conncter>(out Conncter connecterComponent))
        {
            _rigidbody.constraints = RigidbodyConstraints.None;
            MoveForward();
            _movement = true;
            Debug.Log("TriggerStay");
        }
    }


    private void StopBehind()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2f))
        {
            if (hit.collider.CompareTag("wall"))
            {
                Debug.Log("стена");
                _rigidbody.constraints = RigidbodyConstraints.FreezePosition;
                _movement = false;
            }
   
            else if (hit.collider.CompareTag("ball") && hit.rigidbody.velocity == Vector3.zero)
            {
                _rigidbody.constraints = RigidbodyConstraints.FreezePosition;
                _nextBall = hit.collider.GetComponent<Ball>();
                _movement = false;
               // Debug.Log("м€ч");
            }
            else if (_nextBall != null)
            {
                if (_nextBall._movement == true )
                {
                    _rigidbody.constraints = RigidbodyConstraints.None;
                    MoveForward();
                    _movement = true;
                Debug.Log("_nextBall true");
                }
            }
        }
       
        else
        {
            MoveForward();
        }
    }
}
