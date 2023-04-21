using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float leftBound = -17; 

    // Destroy object out of frame
    void Update()
    {
        if (transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }
    }
}
