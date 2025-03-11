using System.Collections;
using System.Collections.Generic;
using TMPro.SpriteAssetUtilities;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    [SerializeField] float _health;

    bool _isDead = false;

    void Start()
    {
        if(_health <= 0) {
            Debug.Log("health‚Ì’l‚ª•s³");
        }
    }

    void Update()
    {
        HealthCheck();
        Dead(_isDead);
    }

    public float Health {
        get { return _health; }
        set { _health = value; }
    }

    void HealthCheck() {
        if (Health <= 0) {
            _isDead = true;
        }
    }

    void Dead(bool isDead) {
        if(isDead) {
            Destroy(gameObject);
        }
    }

    public void DeadImmediately() {
        _isDead = true;
    }

}
