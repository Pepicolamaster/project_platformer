using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controles : MonoBehaviour
{
    [SerializeField]
    private KeyCode right = KeyCode.RightArrow;
    [SerializeField]
    private KeyCode left = KeyCode.LeftArrow;
    [SerializeField]
    private KeyCode jump = KeyCode.Space;
    [SerializeField]
    private Rigidbody2D rgbd;
    [SerializeField]
    private BoxCollider2D groundCollider;
    private bool canJump = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(right)) //Bloc de mouvement horizontal
        {
            rgbd.AddForce(Vector2.right*3);
        }
        else if (Input.GetKey(left))
        {
            rgbd.AddForce(Vector2.left*3);
        }
        /*
        if (Input.GetKeyDown(jump))
        {
            if (rgbd.IsTouchingLayers(LayerMask.GetMask("Ground", "Lava")))
            {
                rgbd.AddForce(Vector2.up * 10, ForceMode2D.Impulse);

            }
        }*/
        if (Input.GetKeyDown(jump))
        {
            if (canJump)
            {
                rgbd.AddForce(Vector2.up * 14, ForceMode2D.Impulse);
                canJump = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }
    }
}
