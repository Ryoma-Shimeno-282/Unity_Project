using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountBaseAttachmentsTest : MonoBehaviour
{
    public GameObject attachment;
    public Vector3 topRail;

    void Start()
    {
        GameObject cone = Instantiate(attachment);
        cone.transform.parent = transform;
        cone.transform.localPosition = topRail;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
