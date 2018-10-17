using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameCore.PlayerController;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]
public class Character3D : MonoBehaviour 
{
	[SerializeField]
    private float moveSpeed = 2.0f;

	//Jump
	private float verticalVelocity;
	private float gravity = 9.8f;
	private float jumpForce = 4f;

	protected bool jumping;
	protected bool shoot;

	protected Animator anim;
	protected CharacterController controller;

    protected float rotY = 0f;

    private void Awake()
    {
		anim = GetComponent<Animator>();
		controller = GetComponent<CharacterController>();	
	}

	private void FixedUpdate()
    {
		Move3D();
		Jump();
	}


	private void Update()
	{
		Shoot();
        Flip();
	}

	protected virtual void Move3D()
	{
        transform.Translate(Vector3.forward * Mathf.Abs(ComponentX) * Time.deltaTime * moveSpeed);
	}

	protected virtual void Jump()
	{
		if(controller.isGrounded)
		{
			verticalVelocity = -gravity * Time.deltaTime;
			if(Btn_jump)
			{
				jumping = Btn_jump;
				verticalVelocity = jumpForce;
			}
		}
        else
		{
			verticalVelocity -= gravity*Time.deltaTime;
		}
		Vector3 moveVector = new Vector3(0,verticalVelocity,0);
		controller.Move(moveVector*Time.deltaTime);
	}

    void Flip()
    {
        rotY = ComponentX > 0f ? 0f : ComponentX < 0f ? 180 : rotY;
        transform.rotation = Quaternion.Euler(new Vector3(0f, rotY, 0f));
    }

	protected virtual void Shoot()
	{
		if(Btn_Fire)
		{
			shoot = true;
		}
	}

	protected float ComponentX
	{
		get
		{
			return ControlSystem.Axis.x;
		}
	}

	protected bool Btn_jump
    {
        get
        {
            return ControlSystem.Btn_jump;
        }
    }

	protected bool Btn_Fire
	{
		get
		{
			return ControlSystem.Btn_fire;
		}
	}
}
