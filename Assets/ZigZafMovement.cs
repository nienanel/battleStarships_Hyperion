using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigZafMovement : MonoBehaviour
{
    public float speed = 3f;
    public float range = 10f;
    public float frencuenci = 3f;
    public float _count = 0;
    public float _startPositionZ;

    private void Start()
    {
        _startPositionZ = this.transform.position.x;
    }

    private void Update()
    {
        _count += frencuenci * Time.deltaTime;

        if (_count >= 6.28f)
        {
            _count = 0;
        }

        float z = _startPositionZ + Mathf.Sin(_count) * range;
        float x = transform.position.x + speed * Time.deltaTime;


        transform.position = new Vector3(x, transform.position.y,z);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
