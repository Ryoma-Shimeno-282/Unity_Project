using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    public int numberOfEnemies;

    EnemyController _enemyController;
    GameObject[] enemySquad;

    void Start()
    {
        if(numberOfEnemies < 0) {
            Debug.Log("敵の数の値が不正");
        } else {
            enemySquad = new GameObject[numberOfEnemies];

            SetEnemySquad(numberOfEnemies);
        }
    }

    void Update()
    {
        
    }

    void SetEnemySquad(int numberOfEnemies) {
        for (int i = 0; i < numberOfEnemies; i++) {
            //スポーン座標
            Vector3[] positions = new Vector3[numberOfEnemies];
            positions[i] = GenerateRandomPosition();

            //配列に生成してそれぞれのスポーンメソッドを呼ぶ
            enemySquad[i] = enemyPrefab;
            _enemyController = enemySquad[i].GetComponent<EnemyController>();
            _enemyController.Spawn(positions[i]);
        }
    }

    Vector3 GenerateRandomPosition() {
        float x = Random.Range(-20f, 20f);
        float z = Random.Range(-20f, 20f);
        Vector3 pos = new Vector3 (x, 1f, z);
        return pos;
    }


}
