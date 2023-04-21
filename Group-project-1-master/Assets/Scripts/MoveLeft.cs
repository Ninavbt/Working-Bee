using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 9;
    private PlayerController playerControllerScript;

    // Move left that is used for background, trees and flowers
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (playerControllerScript.gameOver == false)
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
}
