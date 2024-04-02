using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float _speed = 15;
    private float _leftBound = -10; 

    private PlayerController playerControllerScript;

    private void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if(playerControllerScript._gameOver == false)
        {
            transform.Translate(Vector3.left * _speed * Time.deltaTime);
        }

        if(transform.position.x < _leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(this.gameObject);
        }

    }

}//class
