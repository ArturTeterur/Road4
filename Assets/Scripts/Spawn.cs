using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawn : MonoBehaviour
{
    [SerializeField] private int _spawnCount;
    public int SpawnCount => _spawnCount;
    [SerializeField] private GameObject _spawnPoint;
    [SerializeField] private Ball _ballPrefab;
    [SerializeField] private float _timeSpawn;
    [SerializeField] private List<Ball> _knightList = new List<Ball>();

    private void Start()
    {
        StartCoroutine("WaterCreation");
    }

    private IEnumerator WaterCreation()
    {
        for (int i = 0; i < _spawnCount; i++)
        {
            Ball ball = Instantiate(_ballPrefab, _spawnPoint.transform.position, Quaternion.identity);

            yield return new WaitForSeconds(_timeSpawn);
        }
    }
}
