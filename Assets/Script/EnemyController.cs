using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    Vector3 _initPosition;//�ꉞ�A�����N�����W��ۑ����Ă���

    enum EnemyBehaviour {

    }

    Vector3 InitPosition {
        get { return _initPosition; }
        set { _initPosition = value; } 
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Spawn(Vector3 position) {
        InitPosition = position;
        Instantiate(gameObject, position, Quaternion.identity);
    }

}
