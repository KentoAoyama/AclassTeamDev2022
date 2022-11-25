using System.Collections;
using UnityEngine;

public class Wave : MonoBehaviour
{
    [SerializeField]
    private float _destroyCount = 5f;
    private void Start()
    {
        StartCoroutine(WaveDestroy());
    }
    private IEnumerator WaveDestroy()
    {
        yield return new WaitForSeconds(_destroyCount);
        Destroy(gameObject);
    }
}
