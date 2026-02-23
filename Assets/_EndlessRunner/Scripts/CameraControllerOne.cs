using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerOne : MonoBehaviour
{
    // Reference for Jerry Transform
    [SerializeField] Transform jerryTransform;
    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - jerryTransform.position; // Distance and direction
    }

    // Update is called once per frame
    void Update()
    {
        // Set Main Camera Position
        transform.position = jerryTransform.position + offset; //   0 0 0 + 0 1.5 -3 --> 0 1.5 -3
    }
}
