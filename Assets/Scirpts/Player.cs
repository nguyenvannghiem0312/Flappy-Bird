using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumeForce;
    Rigidbody2D m_rb;
    GameController Game;
   
    // Start is called before the first frame update
    void Start()
    {
        Game = FindObjectOfType<GameController>();
        m_rb = GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_rb.AddForce(Vector2.up * jumeForce);
            }
    }
   
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Score"))
        {
            Game.ScoreIncrease();
        }
    }
}
