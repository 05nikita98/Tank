using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class EngineTank : MonoBehaviour
{
    public float speed = 5f;
    public float rotateSpeed = 50f;

    private Animator anim;
    
    private Rigidbody rb;
    public GameObject Tower;
    public GameObject Bulet;
    public GameObject StartStwol;
    public int TowerSpeed;
   
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Fier();

        Engine();

        TowerRotate();
    }

    private void Fier()
    {
        if (Input.GetMouseButtonUp(0))
        {
            var spawnPoint = StartStwol.transform.position;
            var spawnRoot = StartStwol.transform.rotation;

            var pula = Instantiate(Bulet, spawnPoint, spawnRoot);

            var run = pula.GetComponent<Rigidbody>();
            run.AddForce(pula.transform.forward * 30, ForceMode.Impulse);

            Destroy(pula, 4);
        }
    }
   
    private void TowerRotate()
    {
        var angleRotate = Time.deltaTime * TowerSpeed * Input.GetAxis("Mouse X");
        Tower.transform.Rotate(0, angleRotate, 0);
    }

    private void Engine()
    {
        float horMove = Input.GetAxis("Horizontal");
        float vertMove = Input.GetAxis("Vertical");

        if (horMove > 0)
            transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
        else if (horMove < 0)
            transform.Rotate(Vector3.down * Time.deltaTime * rotateSpeed);

        Vector3 direction = new Vector3(0, 0, vertMove);

        rb.MovePosition(transform.position + transform.TransformDirection(direction * speed * Time.deltaTime));

        if (vertMove > 0 || vertMove < 0)
            anim.SetBool("isGo", true);
        else
            anim.SetBool("isGo", false);
    }
}





