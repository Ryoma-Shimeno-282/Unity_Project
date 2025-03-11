using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GenerateWeapon : MonoBehaviour 
{

    GameObject _root;


    void Start()
    {

        //BuildMk18();
        //RotateGun();
    }

    void Update()
    {
        
    }

    public GameObject BuildMk18() {

        _root = new GameObject("Mk18_root");

        string[] mk18PartsGUID = AssetDatabase.FindAssets("AR-15", new[] { "Assets/Prefab/Mk18" });

        List<string> mk18PartsPath = new List<string>();

        for (int i = 0; i < mk18PartsGUID.Length; i++) {
            mk18PartsPath.Add(AssetDatabase.GUIDToAssetPath(mk18PartsGUID[i]));
        }
        

        GameObject _front_takedownPin
            = Instantiate((GameObject)AssetDatabase.LoadAssetAtPath
                (FindPathFromPartsName("TakedownPin_Front", mk18PartsPath), typeof(GameObject)));


        GameObject _upper
            = Instantiate((GameObject)AssetDatabase.LoadAssetAtPath
                (FindPathFromPartsName("Upper", mk18PartsPath), typeof(GameObject)));
        GameObject _handGuard
            = Instantiate((GameObject)AssetDatabase.LoadAssetAtPath
                (FindPathFromPartsName("HandGuard", mk18PartsPath), typeof(GameObject)));
        GameObject _barrel
            = Instantiate((GameObject)AssetDatabase.LoadAssetAtPath
                (FindPathFromPartsName("Barrel", mk18PartsPath), typeof(GameObject)));
        GameObject _muzzle
            = Instantiate((GameObject)AssetDatabase.LoadAssetAtPath
                (FindPathFromPartsName("Muzzle", mk18PartsPath), typeof(GameObject)));
        GameObject _chargingHandle
            = Instantiate((GameObject)AssetDatabase.LoadAssetAtPath
                (FindPathFromPartsName("ChargingHandle", mk18PartsPath), typeof(GameObject)));
        GameObject _dustCover
            = Instantiate((GameObject)AssetDatabase.LoadAssetAtPath
                (FindPathFromPartsName("DustCover", mk18PartsPath), typeof(GameObject)));


        GameObject _lower
            = Instantiate((GameObject)AssetDatabase.LoadAssetAtPath
                (FindPathFromPartsName("Lower", mk18PartsPath), typeof(GameObject)));
        GameObject _rifleGrip
            = Instantiate((GameObject)AssetDatabase.LoadAssetAtPath
                (FindPathFromPartsName("RifleGrip", mk18PartsPath), typeof(GameObject)));
        GameObject _boltRelease
            = Instantiate((GameObject)AssetDatabase.LoadAssetAtPath
                (FindPathFromPartsName("BoltRelease", mk18PartsPath), typeof(GameObject)));
        GameObject _magRelease
            = Instantiate((GameObject)AssetDatabase.LoadAssetAtPath
                (FindPathFromPartsName("MagRelease", mk18PartsPath), typeof(GameObject)));
        GameObject _fireSelect
            = Instantiate((GameObject)AssetDatabase.LoadAssetAtPath
                (FindPathFromPartsName("FireSelect", mk18PartsPath), typeof(GameObject)));
        GameObject _back_takedownPin
            = Instantiate((GameObject)AssetDatabase.LoadAssetAtPath
                (FindPathFromPartsName("TakedownPin_Back", mk18PartsPath), typeof(GameObject)));
        GameObject _trigger
            = Instantiate((GameObject)AssetDatabase.LoadAssetAtPath
                (FindPathFromPartsName("Trigger", mk18PartsPath), typeof(GameObject)));
        GameObject _triggerGuard
            = Instantiate((GameObject)AssetDatabase.LoadAssetAtPath
                (FindPathFromPartsName("TriggerGuard", mk18PartsPath), typeof(GameObject)));
        GameObject _stockTube
            = Instantiate((GameObject)AssetDatabase.LoadAssetAtPath
                (FindPathFromPartsName("StockTube", mk18PartsPath), typeof(GameObject)));
        GameObject _stock
            = Instantiate((GameObject)AssetDatabase.LoadAssetAtPath
                (FindPathFromPartsName("Stock", mk18PartsPath), typeof(GameObject)));

        //ˆÊ’uŒˆ‚ß
        _front_takedownPin.transform.position = _root.transform.position + new Vector3(0.133f, -0.027f, -0.018f);
        _upper.transform.position = _root.transform.position;
        _lower.transform.position = _root.transform.position;
        _handGuard.transform.position = _root.transform.position + new Vector3(0.137f, 0, 0);
        _barrel.transform.position = _root.transform.position + new Vector3(0.137f, 0, 0);
        _muzzle.transform.position = _root.transform.position + new Vector3(0.414f, 0, 0);
        _chargingHandle.transform.position = _root.transform.position + new Vector3(-0.068f, 0.028f, 0);
        _dustCover.transform.position = _root.transform.position + new Vector3(0.027f, -0.007f, -0.019f);

        _rifleGrip.transform.position = _root.transform.position + new Vector3(-0.016f, -0.058f, 0);
        _boltRelease.transform.position = _root.transform.position + new Vector3(0.042f, -0.025f, 0.018f);
        _magRelease.transform.position = _root.transform.position + new Vector3(0.046f, -0.044f, -0.018f);
        _fireSelect.transform.position = _root.transform.position + new Vector3(-0.026f, -0.042f, -0.017f);
        _back_takedownPin.transform.position = _root.transform.position + new Vector3(-0.049f, -0.028f, -0.015f);
        _trigger.transform.position = _root.transform.position + new Vector3(0.005f, -0.072f, 0);
        _triggerGuard.transform.position = _root.transform.position + new Vector3(0.005f, -0.089f, 0);
        _stockTube.transform.position = _root.transform.position + new Vector3(-0.084f, 0.016f, 0);
        _stock.transform.position = _root.transform.position + new Vector3(-0.1f, 0.013f, 0);



        //eŒˆ‚ß
        //_root.transform.parent = transform;

        _front_takedownPin.transform.parent = _root.transform;

        _upper.transform.parent = _front_takedownPin.transform;

        _dustCover.transform.parent = _upper.transform;
        _chargingHandle.transform.parent = _upper.transform;
        _handGuard.transform.parent = _upper.transform;
        _barrel.transform.parent = _upper.transform;

        _muzzle.transform.parent = _barrel.transform;

        _lower.transform.parent = _root.transform;
        _back_takedownPin.transform.parent = _lower.transform;
        _trigger.transform.parent = _lower.transform;
        _triggerGuard.transform.parent = _lower.transform;
        _rifleGrip.transform.parent = _lower.transform;
        _fireSelect.transform.parent = _lower.transform;
        _magRelease.transform.parent = _lower.transform;
        _boltRelease.transform.parent = _lower.transform;
        _stockTube.transform.parent = _lower.transform;

        _stock.transform.parent = _stockTube.transform;

        return _root;
    }

    public void InitiateGunPosition() {
        _root.transform.rotation = Quaternion.AngleAxis(180.0f, new Vector3(0, 1, 0));
        _root.transform.position = new Vector3(0.1f, 0, 0);
    }

    string FindPathFromPartsName(string partsName, List<string> pathList) {
        for (int i = 0; i < pathList.Count; i++) {
            if (pathList[i].Contains(partsName)) {
                return pathList[i];
            }
        }
        return "";
    }
}
