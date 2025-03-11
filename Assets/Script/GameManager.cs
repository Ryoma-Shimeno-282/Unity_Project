using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    void Awake() {
        InitCursor();
    }

    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    void InitCursor() {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
