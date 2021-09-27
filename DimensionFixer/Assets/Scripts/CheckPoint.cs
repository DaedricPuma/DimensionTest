using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private GameController game;
    private bool active = false;
    public GameObject activeAura;
    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (!active)
        {


            if (collider.gameObject.CompareTag("Player"))
            {
                game.CheckPoint(this);
                Color color = GetComponent<SpriteRenderer>().color;
                GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, 1.0f);
                activeAura.SetActive(true);
                active = true;
            }
        }
    }
}
