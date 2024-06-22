using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    public Transform target;
    Camera cam;
    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    private void Update()
    {
        Vector3 screenPos = cam.WorldToScreenPoint(target.position);
    }
}
