using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public enum CharacterState
{
    idle,
    Attack
}

public class character : MonoBehaviour
{
    // Start is called before the first frame update
    public float movementSpeed;
    protected Vector2 velocity;
    protected Rigidbody2D body;
    protected Animator animator;


    SpriteRenderer spriteRenderer;
    protected virtual void Start()
    {
      body= GetComponent<Rigidbody2D>();
        animator= GetComponent<Animator>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (velocity.x > 0)
        {
            animator.Play("Right");
        }
        else if (velocity.x < 0)
        {
            animator.Play("Left");
        }
        else if (velocity.y > 0)
        {
            animator.Play("Up");
        }
        else if (velocity.y < 0)
        {
            animator.Play("Down");
        }
        else
        {
            animator.Play("Idle");
        }
    }
}
