using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OmniShootController : MonoBehaviour
{
    public Shoot shootPrefab;
    public float speed = 2;

    private int shootTracker = 0;

    public void setShoots(int shoots)
    {
        shootTracker = shoots;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(this.transform.position, this.transform.position + (Vector3)Vector2.up * 4);
        Gizmos.DrawLine(this.transform.position, this.transform.position + (Vector3)Vector2.down * 4);
        Gizmos.DrawLine(this.transform.position, this.transform.position + (Vector3)Vector2.left * 4);
        Gizmos.DrawLine(this.transform.position, this.transform.position + (Vector3)Vector2.right * 4);
    }

    void Shoot()
    {
        Shoot[] shoots = new Shoot[4];
        Vector2[] speeds = { Vector2.up, Vector2.right, Vector2.down, Vector2.left };

        for (int i=0; i<4; i++)
        {
            shoots[i] = Instantiate(shootPrefab);
            shoots[i].transform.position = this.transform.position;
            shoots[i].speed = speeds[i] * this.speed;
        }
        this.shootTracker--;

        if (this.shootTracker <= 0)
        {
            Destroy(this);
            //this.enabled = false;
            gameObject.GetComponent<ShootingController>().enabled = true;
        }
    }
}
