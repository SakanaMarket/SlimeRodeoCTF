using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMoves : MonoBehaviour
{
    [SerializeField] private Rigidbody2D spoder;
    [SerializeField] private bool side;
    [SerializeField] private bool isFacingRight;
    [SerializeField] private bool isFacingUp;
    private float moveSpeed = 2f;

    private void Awake()
    {
        if(isFacingRight)
        {
            Vector3 obj_scale = transform.localScale;
            obj_scale.x *= -1;
            transform.localScale = obj_scale;
        }
    }
    void Update()
    {
        if (side == true)
        {
            if (isFacingRight == true)
            {
                transform.Translate(moveSpeed * 2 * Time.deltaTime, 0f, 0f);
                //spoder.AddForce(new Vector2(.1f * moveSpeed * Time.deltaTime, 0f));
            }
            else
            {
                transform.Translate(-moveSpeed * 2 * Time.deltaTime, 0f, 0f);
                //spoder.AddForce(new Vector2(-.1f * moveSpeed * Time.deltaTime, 0f));
            }
            
        }
        else
        {
            if (isFacingUp == true)
            {
                transform.Translate(0f, moveSpeed * 2 * Time.deltaTime, 0f);
                //spoder.AddForce(new Vector2(.1f * moveSpeed * Time.deltaTime, 0f));
            }
            else
            {
                transform.Translate(0f, -moveSpeed * 2 * Time.deltaTime, 0f);
                //spoder.AddForce(new Vector2(-.1f * moveSpeed * Time.deltaTime, 0f));
            }
        }
    }

    private void Flip()
    {
        if (side)
        {
            isFacingRight = !isFacingRight;
        }
        else
        {
            isFacingUp = !isFacingUp;
        }
        
        Vector3 obj_scale = transform.localScale;
        obj_scale.x *= -1;
        transform.localScale = obj_scale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            Flip();
            Debug.Log("Fuck");
        }
        else if (collision.gameObject.tag == "Player")
        {

        }
    }
}
