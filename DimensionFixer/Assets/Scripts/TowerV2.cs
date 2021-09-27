using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerV2 : MonoBehaviour
{
    public float radius = 0.2f;
    public Shoot shootPrefab;
    public float interval = 5;
    public float speed = 3;
    private float tracker = 0;

    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        tracker -= Time.deltaTime;
        if (tracker <= 0)
        {
            tracker = 0;
        }
        if (Vector2.Distance(this.transform.position, player.transform.position) <= radius && tracker <= 0)
        {
            GetComponent<Animator>().SetBool("Shooting", true);
            tracker += interval;
            Shoot shoot = Instantiate(shootPrefab);
            shoot.transform.position = this.transform.position;

            shoot.SetDirection((player.transform.position - this.transform.position).normalized, speed);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, radius);
    }

    public void ShootingEnd(string message)
    {
        if (message.Equals("ShootingFinished"))
        {
            GetComponent<Animator>().SetBool("Shooting", false);
        }
    }
}
