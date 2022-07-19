using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int playerSpeed = 5;
    Vector2Int facing;
    Vector2 moveInput;

    Rigidbody2D _rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        facing = Vector2Int.right;
        _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _rigidbody2D.position += moveInput * playerSpeed * Time.deltaTime;

        if (_rigidbody2D.velocity.magnitude < .01)
        {
         _rigidbody2D.velocity = Vector2.zero;
        } 

        HandleFacing();
    }

    void HandleFacing()
    {
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            if(facing != Vector2Int.right)
            {
                facing = Vector2Int.right;
            }
        }
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            if(facing != Vector2Int.left)
            {
                facing = Vector2Int.left;
            }
        }
        transform.localScale = new Vector3(facing.x, transform.localScale.y, transform.localScale.z);
    }

}
