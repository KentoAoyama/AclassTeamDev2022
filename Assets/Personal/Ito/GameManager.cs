using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float WaveCenterCount { get => _waveCenterCount; set => _waveCenterCount = value; }
    [SerializeField] private float _waveCenterCount;
    public float Time { get => _time; set => _time = value; }
    [SerializeField] private float _time;
}
