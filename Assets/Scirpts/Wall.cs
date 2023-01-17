using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public float moveSpeed;
    GameController Game;
    UI m_ui;
    // Start is called before the first frame update
    void Start()
    {
        Game = FindObjectOfType<GameController>();
        m_ui = FindObjectOfType<UI>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position +
            Vector3.left * moveSpeed * Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            m_ui.ShowPanel(true);
            Game.EndGame();
            Game.GetGameOver(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish"))
        {
            Destroy(gameObject);
        }
    }
}
