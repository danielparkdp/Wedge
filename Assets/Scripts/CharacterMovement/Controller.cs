using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    public int maxHealth = 5;
    public float speed = 3.5f;
    public int health { get { return currentHealth; }}
    int currentHealth;
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    Animator animator;

    /*
    For my game, it will be North = 0, East = 1, South = 2, West = 3
    */
    public int direction = 2;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        currentHealth = 3;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");


    }

    void FixedUpdate()
    {
      Vector2 position = transform.position;
      position.x = position.x + speed * horizontal * Time.deltaTime;
      position.y = position.y + speed * vertical * Time.deltaTime;
      if (Mathf.Abs(horizontal) > Mathf.Abs(vertical)) {
        if (horizontal > 0.05f){
          direction = 1;
        } else if (horizontal < -0.05f){
          direction = 3;
        }
      } else {
        if (vertical > 0.05f) {
          direction = 0;
        } else if (vertical < -0.05f){
          direction = 2;
        }
      }

      animator.SetFloat("Move X", horizontal);
      animator.SetFloat("Move Y", vertical);
      animator.SetFloat("Direction", direction*1.0f/4.0f+0.0005f);
      rigidbody2d.MovePosition(position);
    }

    public void ChangeHealth(int amount)
    {
      currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
      Debug.Log(currentHealth + "/" + maxHealth);
    }
}
