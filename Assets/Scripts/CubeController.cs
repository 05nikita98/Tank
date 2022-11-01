using UnityEngine;

public class CubeController : MonoBehaviour  {

    public float speed = 5f, rotateSpeed = 3f, jumpForce = 50f;

    private Rigidbody rb;
    private AudioSource steps, jumpAudio;

    private Animator anim;

    private bool isAim;

    private void Start() {
        rb =  GetComponent<Rigidbody>();
        steps = GetComponent<AudioSource>();
        jumpAudio = transform.GetChild(0).GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    private void Update() {
        float horMove = Input.GetAxis("Horizontal");
        float vertMove = Input.GetAxis("Vertical");

        if (horMove > 0)
            transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
        else if (horMove < 0)
            transform.Rotate(Vector3.down * Time.deltaTime * rotateSpeed);

        if ((vertMove > 0 || vertMove < 0) && !steps.isPlaying)
            steps.Play();
        else if (vertMove == 0 && steps.isPlaying)
            steps.Pause();

        if(Input.GetAxis("Jump") > 0 && rb.velocity.y == 0f) {
            rb.AddForce(Vector3.up * jumpForce);
            jumpAudio.Play();
        }

        Vector3 direction = new Vector3(0, 0, vertMove);
        //rb.AddForce(new Vector3(horMove, 0, vertMove) * speed);
        //rb.velocity = direction * speed;

        if (vertMove > 0 || vertMove < 0)
            anim.SetBool("isWalking", true);
        else
            anim.SetBool("isWalking", false);

        rb.MovePosition(transform.position + transform.TransformDirection(direction * speed * Time.deltaTime));

        if(Input.GetMouseButtonDown(1)) {
            if(!isAim) {
                anim.SetTrigger("isAim");
                anim.SetBool("notAim", false);
            } else {
                anim.ResetTrigger("isAim");
                anim.SetBool("notAim", true);
            }
            isAim = !isAim;
        }
    }


}
