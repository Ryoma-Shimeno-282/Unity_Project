using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLIghtController : MonoBehaviour
{
    public float speed;

    float _rotationY = 0;
    Vector3 _originV3;
    Quaternion _originQ;

    // Start is called before the first frame update
    void Start()
    {
        
        _originQ = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        RotateLight(speed);
    }

    void RotateLight(float speed) {

        transform.Rotate(0, speed * Time.deltaTime, 0, Space.World);
        _rotationY += speed * Time.deltaTime;


        if(_rotationY >= 180) {
            transform.rotation = _originQ;
            _rotationY = 0;
        }
    }
}
