using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char : MonoBehaviour
{
    [SerializeField] private float jumpPower;
    [SerializeField] private LayerMask layerMask;

    Rigidbody2D rb2d;
    CircleCollider2D cc2d;
    Animator animator;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Hit Enemy!");
            GameManager._instance.ShowGameOver();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        cc2d = GetComponent<CircleCollider2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z) && isGrounded())
        {
            rb2d.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
        }

        animator.SetFloat("velY", rb2d.velocity.y);
        animator.SetBool("isGround", isGrounded()); 
    }
    private bool isGrounded()
    {
        float extra = 0.1f;
        RaycastHit2D raycastHit = Physics2D.Raycast(cc2d.bounds.center, Vector2.down, cc2d.bounds.extents.y + extra, layerMask);

        Color rayColor;
        if (raycastHit.collider != null)
            rayColor = Color.green;
        else
            rayColor = Color.red;

        Debug.DrawRay(cc2d.bounds.center, Vector2.down * (cc2d.bounds.extents.y + extra), rayColor);

        return raycastHit.collider != null;
    }
}
