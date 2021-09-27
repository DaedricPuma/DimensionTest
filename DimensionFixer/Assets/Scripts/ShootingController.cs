using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public Shoot shootPrefab;
    public Shoot oldShoot;
    public float speed = 2;
    public float attackSpeed = 1.0f;
    public float reloadTracker;
    private Vector2 target;
    private float powerUpTracker = 0;
    private Shoot oldPrefab;
    public GameController gameC;
    public AudioClip shootSound;
    public AudioSource audioSourceShooting;

    // Start is called before the first frame update
    void Start()
    {
        gameC = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        audioSourceShooting = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position;

        if (Input.GetMouseButtonDown(0))
        {
            if (reloadTracker == 0 && gameC.gameIsPaused == false)
            {
                audioSourceShooting.PlayOneShot(shootSound, 0.6f);
                Shoot();
                reloadTracker = attackSpeed;
            }
            
        }
        if (reloadTracker > 0)
        {
            reloadTracker -= Time.deltaTime;
        }
        if (reloadTracker < 0)
        {
            reloadTracker = 0;
        }

        if (powerUpTracker > 0) powerUpTracker -= Time.deltaTime;
        
        if(powerUpTracker < 0)
        {
            this.shootPrefab = oldPrefab;
            this.powerUpTracker = 0;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawLine(this.transform.position, this.transform.position + (Vector3)target);
    }

    void Shoot()
    {

        Shoot shoot = Instantiate(shootPrefab);
        shoot.transform.position = this.transform.position;
        shoot.speed = target.normalized * speed;
    }

    void CancelPowerUp()
    {
        this.shootPrefab = oldPrefab;
        oldPrefab = null;
    }

    public void PowerUp (Shoot shootPrefab, float time)
    {
        oldPrefab = this.shootPrefab;
        this.shootPrefab = shootPrefab;

        Invoke("CancelPowerUp", time);
        //this.powerUpTracker = time;
    }
}
