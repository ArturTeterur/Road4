using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{
    [SerializeField] GameObject connectedPipe;
    [SerializeField] private Platform platform;
    [SerializeField] private bool _pipeInWater;
    public bool PipeInWater => _pipeInWater;
    [SerializeField] private GameObject[] _componentWater;
    [SerializeField] private float _raycastDistance;
    [SerializeField] private PlatformTrigger _platformTriggerTwo;


  
}