using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private float interval;

    private float _time = 0f;
    private float _randTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        _randTime = Random.Range(1f, interval);
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;

        if(_time >= _randTime)
        {
            _time = 0f;
            _randTime = Random.Range(1f, interval);
            var obj = Instantiate(enemy, transform.position, Quaternion.identity);
        }
    }
}
