using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    [SerializeField] GameObject _canvasFinish;
    [SerializeField] GameObject _firstStar;
    [SerializeField] GameObject _secondStar;
    [SerializeField] GameObject _thirdStar;
    private int _currentAmountBalls = 0;
    private Spawn _spawn;
    private int _spawnCount; // сколько изначально шариков
    private int _currentPercent;


    private void Start()
    {
        _spawn = FindObjectOfType<Spawn>();
        _spawnCount = _spawn.SpawnCount;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.TryGetComponent<BallTrigger>(out BallTrigger ballComponent))
        {
            _currentAmountBalls++;  // сколько пришло
            if (_spawnCount == _currentAmountBalls)
            {
                Finish();
            }        
        }
    }

    private void Finish()
    {
        _currentPercent =  _currentAmountBalls % _spawnCount * 100;
        _canvasFinish.SetActive(true);
        if (_currentPercent >= 30)
        {
            _firstStar.SetActive(true);
        }
        if (_currentPercent >= 60)
        {
            _secondStar.SetActive(true);
        }
        if (_currentPercent >= 90)
        {
            _thirdStar.SetActive(true);
        }
        Time.timeScale = 0f;
    }

    public void TakeAwayBall()
    {
        _spawnCount--;
    }
}
