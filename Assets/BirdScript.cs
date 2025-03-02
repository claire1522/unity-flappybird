using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public SpriteRenderer birdwingup;
    public SpriteRenderer birdwingdown;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        birdwingup.enabled = true;
        birdwingdown.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            myRigidBody.velocity = Vector2.up * flapStrength;
            birdwingup.enabled = false;
            birdwingdown.enabled = true;
            StartCoroutine(Resetwings());
        }

        if (transform.position.y > 25 || transform.position.y < -25)
        {
            birdIsAlive = false;
            logic.gameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }

    IEnumerator Resetwings()
    {
        yield return new WaitForSeconds(0.1f);
        birdwingup.enabled = true;
        birdwingdown.enabled = false;   
    }

    

}
