using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumetricLightController : MonoBehaviour
{
    public float speed;
    public float maxY;
    public float minY;
    public float lightDecayValue;
    public float lightDecayStart;

    Light volLight;

    float _originX;
    float _originY;
    float _originZ;

    float _intensity;
    float _lerpT = 0.0f;

    // Start is called before the first frame update
    void Start()
    {


        volLight = GetComponent<Light>();
        _intensity = volLight.intensity;

        _originX = transform.position.x;
        _originY = transform.position.y;
        _originZ = transform.position.z;

        transform.position = new Vector3(_originX, maxY, _originZ);
    }

    // Update is called once per frame
    void Update()
    {
        MoveLightVert(speed);
    }

    void MoveLightVert(float speed)
    {
        transform.Translate(0, -speed * Time.deltaTime, 0, Space.World);

        if (transform.position.y <= lightDecayStart) {
            volLight.intensity = Mathf.Lerp(_intensity, 0, _lerpT);
            _lerpT += lightDecayValue * Time.deltaTime;
        }

        if (transform.position.y < minY) {
            transform.position = new Vector3(_originX, maxY, _originZ);
            volLight.intensity = _intensity;
            _lerpT = 0;
        }
        

    }
}
