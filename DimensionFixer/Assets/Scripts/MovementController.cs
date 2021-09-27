using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
	private Rigidbody2D rigidBody;
	
	public float speed = 0.2f;
    public float jumpPower = 0.5f;
    public float groundRay = 1f;
    private bool grounded = true;
    private float height;
    public bool dashing = false;
    public float dashDuration = 0.2f;
    private int extraJump = 0;
    public int extraJumpCount = 1;
    public GameController gameC;
    public AudioClip jumpSound;
    public AudioClip dashSound;
    public AudioSource audioSourceMovement;
    public float raycastOffsetRight = 0.15f;
    public float raycastOffsetLeft = 0.15f;

    // to do : intensidade do pulo conforme tempo de pressão do botão

    public float flatDashCD = 5f;
    private float dashTracker = 0f;
    public float dashPower = 50f;


    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        height = GetComponent<SpriteRenderer>().bounds.size.y / 2;
        gameC = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        audioSourceMovement = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float height = GetComponent<SpriteRenderer>().bounds.size.y / 2;
        

        if (Input.anyKey == false)
        {
            GetComponent<Animator>().SetInteger("Walk", 0);
        }

        if (Input.GetKey(KeyCode.D) && dashTracker < flatDashCD -dashDuration && gameC.gameIsPaused == false)//Input.GetKey(KeyCode.LeftShift) == false)
        {
            if (grounded) { GetComponent<Animator>().SetInteger("Walk", 1); }
            
            //rigidBody.MovePosition((Vector2)this.transform.position + new Vector2(+speed, 0));
            rigidBody.velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
            GetComponent<SpriteRenderer>().flipX = false;
            
        }
        if (Input.GetKey(KeyCode.A) && dashTracker < flatDashCD - dashDuration && gameC.gameIsPaused == false)//Input.GetKey(KeyCode.LeftShift) == false)
        {
            if (grounded) { GetComponent<Animator>().SetInteger("Walk", 1); }
            GetComponent<SpriteRenderer>().flipX = true;
            //rigidBody.MovePosition((Vector2)this.transform.position + new Vector2(-speed, 0));
            rigidBody.velocity = new Vector2(-speed, GetComponent<Rigidbody2D>().velocity.y);
        }
        if (Input.GetKeyDown(KeyCode.Space) && (grounded) && gameC.gameIsPaused == false)
        {
            //GetComponent<Animator>().SetTrigger("JumpTrig");
            GetComponent<Animator>().SetInteger("Jump", 1);

            audioSourceMovement.PlayOneShot(jumpSound, 0.6f);
            rigidBody.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
            
        }else if (Input.GetKeyDown(KeyCode.Space) && extraJump > 0 && (!grounded) && gameC.gameIsPaused == false)
        {
            GetComponent<Animator>().SetInteger("DoubleJump", 1);
            //GetComponent<Animator>().SetTrigger("DJTrig");
            audioSourceMovement.PlayOneShot(jumpSound, 0.6f);
            rigidBody.velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0);
            rigidBody.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
            extraJump = 0;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKey(KeyCode.A) && dashTracker == 0 && gameC.gameIsPaused == false)// && dashing == false)
        {
            audioSourceMovement.PlayOneShot(dashSound, 0.4f);
            rigidBody.AddForce(new Vector2(-dashPower, 0), ForceMode2D.Impulse);
            GetComponent<Animator>().SetInteger("Dashing", 1);
            GetComponent<Animator>().SetInteger("Jump", 0);
            GetComponent<Animator>().SetInteger("DoubleJump", 0);
            //rigidBody.velocity = new Vector2(-dashPower, GetComponent<Rigidbody2D>().velocity.y);
            //rigidBody.MovePosition(this.transform.position - new Vector3(dashPower, 0));
            dashTracker = flatDashCD;
            //dashing = true;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKey(KeyCode.D) && dashTracker == 0 && gameC.gameIsPaused == false)// && dashing == false)
        {
            audioSourceMovement.PlayOneShot(dashSound, 0.4f);
            rigidBody.AddForce(new Vector2(dashPower, 0), ForceMode2D.Impulse);
            GetComponent<Animator>().SetInteger("Dashing", 1);
            GetComponent<Animator>().SetInteger("Jump", 0);
            GetComponent<Animator>().SetInteger("DoubleJump", 0);
            //rigidBody.velocity = new Vector2(dashPower, GetComponent<Rigidbody2D>().velocity.y);
            //rigidBody.MovePosition(this.transform.position - new Vector3(-dashPower, 0));
            dashTracker = flatDashCD;
            //dashing = true;
        }

        if (dashTracker > 0)
        {
            dashTracker -= Time.deltaTime;
        }
        if (dashTracker < 1)
        {
            dashTracker = 0;
            //dashing = false;
        }

        RaycastHit2D[] hits = Physics2D.RaycastAll(this.transform.position , new Vector3(0 + raycastOffsetRight, -1.1f, 0), height + groundRay, LayerMask.GetMask("Level"));
        RaycastHit2D[] hits2 = Physics2D.RaycastAll(this.transform.position, new Vector3(0 - raycastOffsetLeft, -1.1f, 0), height + groundRay, LayerMask.GetMask("Level"));

        if (hits.Length > 0)
        {
            grounded = true; extraJump = extraJumpCount;
        }
        else if (hits2.Length > 0)
        {
            grounded = true; extraJump = extraJumpCount;
        }
        else
        {
            StartCoroutine ( MakeGroundedFalse());
            //grounded = false;
        }

        if (rigidBody.velocity.y < -0.2f && grounded == false && GetComponent<Animator>().GetInteger("DoubleJump") == 0)
        {
            GetComponent<Animator>().SetInteger("Fall", 1);
        }
        else
        {
            GetComponent<Animator>().SetInteger("Fall", 0);
        }
    }

    public void DashEnd(string message)
    {
        if (message.Equals("DashFinished"))
        {
            GetComponent<Animator>().SetInteger("Dashing", 0);
        }
    }

    public void DJEnd(string message)
    {
        if (message.Equals("DoubleEnd"))
        {
            GetComponent<Animator>().SetInteger("DoubleJump", 0);
            GetComponent<Animator>().SetInteger("Jump", 0);
        }
    }

    public void JumpEnd(string message)
    {
        if (message.Equals("FinishedJump"))
        {
            GetComponent<Animator>().SetInteger("Jump", 0);
        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("MovingPlatform"))
        {
            this.transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("MovingPlatform"))
        {
            this.transform.parent = null;
        }
    }


    public IEnumerator MakeGroundedFalse()
    {
        yield return new WaitForSeconds(0.2f);
        grounded = false;
        

    }
}
