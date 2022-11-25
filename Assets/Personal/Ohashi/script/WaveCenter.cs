using System.Collections;
using UnityEngine;

public class WaveCenter : MonoBehaviour
{
    [SerializeField]
    private GameObject _wave;
    [SerializeField]
    private float _waveCountDown = 3f;

    private Animator _anim;
    private bool _isWave = false;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if(!_isWave)
        {
            _isWave = true;
            StartCoroutine(Wave());
        }
    }
    private IEnumerator Wave()
    {
        yield return new WaitForSeconds(_waveCountDown);
        Instantiate(_wave, transform.position, transform.rotation);
        _anim.Play("Count");
        _isWave = false;
    }
}
