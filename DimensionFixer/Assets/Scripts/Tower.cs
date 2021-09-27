using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float radius = 5;

    //private Vector2 target;
    private GameObject player;

    private float targetAngle = 30;

    public float scanSpeed = 90;
    public float scanAngle = 30;

    private bool scanning = true;


    public Shoot shootPrefab;
    public float interval = 5;
    public float speed = 3;
    private float tracker = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = this.player.transform.position - this.transform.position;
        float playerAngle = Vector2.Angle(Vector2.up, dir);
        tracker -= Time.deltaTime;

        if (tracker <= 0)
        {
            tracker = 0;
        }

        if (scanning)
        {
            targetAngle += scanSpeed * Time.deltaTime;
            if (targetAngle >= 360) targetAngle -= 360;

            if (dir.magnitude <= radius)
            {
                if (Vector2.Dot(Vector2.right, dir) < 0) playerAngle = 360 - playerAngle;

                if (playerAngle > targetAngle - scanAngle && playerAngle < targetAngle + scanAngle)
                {
                    scanning = false;
                    
                }
            }
        }
        else
        {

            if (tracker == 0)

            {
                tracker += interval;
                Shoot shoot = Instantiate(shootPrefab);
                shoot.transform.position = this.transform.position;

                shoot.SetDirection((player.transform.position - this.transform.position).normalized, speed);
            }

            targetAngle = playerAngle;
            if (Vector2.Dot(Vector2.right, dir) < 0) targetAngle *= -1;

            if (dir.magnitude > radius)
            {
                scanning = true;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.grey;
        Gizmos.DrawWireSphere(this.transform.position, this.radius);

        Gizmos.color = Color.red;

        float radAngle = targetAngle * Mathf.Deg2Rad;

        Vector2 target = new Vector2(Mathf.Sin(radAngle), Mathf.Cos(radAngle));
        Gizmos.DrawLine(this.transform.position, this.transform.position + (Vector3)target * radius);

        Gizmos.color = Color.blue;
        float angleMin = (targetAngle - scanAngle / 2) * Mathf.Deg2Rad;
        float angleMax = (targetAngle + scanAngle / 2) * Mathf.Deg2Rad;

        Vector2 targetMin = new Vector2(Mathf.Sin(angleMin), Mathf.Cos(angleMin));
        Vector2 targetMax = new Vector2(Mathf.Sin(angleMax), Mathf.Cos(angleMax));

        Gizmos.DrawLine(this.transform.position, this.transform.position + (Vector3)targetMin * radius);
        Gizmos.DrawLine(this.transform.position, this.transform.position + (Vector3)targetMax * radius);
    }
}
