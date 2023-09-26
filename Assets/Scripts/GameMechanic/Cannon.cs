using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cannon : MonoBehaviour
{
    Camera cam;
    Rigidbody2D rb;

    [SerializeField] HingeJoint2D[] wheels;
    JointMotor2D motor;

    [SerializeField] float cannonSpeed;
    public bool isMoving = false;
    float screenBounds;
    Vector2 pos;
    float velocityX = 1;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        pos = rb.position;

        motor = wheels[0].motor;    

    }

    // Update is called once per frame
    void Update()
    {
        isMoving = Input.GetMouseButton(0);

        //xác định vị trí điểm nhấn chuột(hoặc màn hình)
        if (isMoving)
        {
            pos.x = cam.ScreenToWorldPoint(Input.mousePosition).x;
        }
    }

    private void FixedUpdate()
    {
        //Move the cannon
        if (isMoving && !IsButtonClick())
        {
            rb.MovePosition(Vector2.Lerp(rb.position, pos, cannonSpeed * Time.fixedDeltaTime));
        }
        else
        {
            rb.velocity = Vector2.zero;
        }

        //Rotate wheels
        if (isMoving)
        {
            if(pos.x > transform.position.x)
            {
                motor.motorSpeed = velocityX * 150f;
                MotorActivate(true);
            }
            else if(pos.x < transform.position.x)
            {
                motor.motorSpeed = velocityX * -150f;
                MotorActivate(true);
            }
        }
        else
        {
            motor.motorSpeed = 0f;
            MotorActivate(false);
        }
    }

    void MotorActivate(bool isActive)
    {
        wheels[0].useMotor = isActive;
        wheels[1].useMotor = isActive;

        wheels[0].motor = motor;
        wheels[1].motor = motor;
    }

    private bool IsButtonClick()
    {
        if(EventSystem.current == null)
        {
            return false;
        }

        return EventSystem.current.IsPointerOverGameObject();
    }

    
}
