using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    private Vector2 direction;
    private Rigidbody2D rb;
    Animator anims;
    public VectorValue pos;
    //int missionId = 5;
    public int money = 0;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = pos.initialValue;
        rb = GetComponent<Rigidbody2D>();
        anims = GetComponent<Animator>();
       
        //SetMission();
    }

    // Update is called once per frame
    void Update()
    {
        Flip();
        if (Input.GetAxis("Horizontal") == 0 || Input.GetAxis("Vertical") == 0)
        {
            anims.SetInteger("State", 1);
        }
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            anims.SetInteger("State", 2);
        }
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
        

    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }

    void Flip()
    {
        if(Input.GetAxis("Horizontal") > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }

    //public void SetMission()
    //{
    //    missionId = PlayerPrefs.HasKey("missionId") ? PlayerPrefs.GetInt("missionId") : 0;
    //}
}
