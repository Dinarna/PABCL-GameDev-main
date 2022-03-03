using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    [SerializeField] private float speed = -3f;
    [SerializeField] private bool collider = false;
    private float width;

    private BoxCollider2D box2d;
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        box2d = GetComponent<BoxCollider2D>();
        rb2d = GetComponent<Rigidbody2D>();

        width = box2d.size.x;
        box2d.enabled = collider;
        rb2d.velocity = new Vector2(speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -width)
        {
            Reposition();
        }
    }
    private void Reposition()
    {
        Vector2 pos = new Vector2(width * 2f, 0);
        transform.position = (Vector2)transform.position + pos;
    }
}
