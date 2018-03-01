using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Animator))]
public class BroomPlayerCharacter : MonoBehaviour {
	[SerializeField] float m_MovingTurnSpeed = 90 ;
	[SerializeField] float m_StationaryTurnSpeed = 180 ;
	[SerializeField] float m_MoveSpeedMultiplier = 1f; //Move speed multiplier 
	[SerializeField] float m_AnimSpeedMultiplier = 1f;

	Rigidbody m_Rigidbody;
	Animator m_Animator;
	const float k_Half = 0.5f;
	float m_TurnAmount;
	float m_ForwardAmount;
	float m_CapsuleHeight;
	Vector3 m_CapsuleCenter;
	CapsuleCollider m_Capsule;
	bool m_Acceleration;
	//Vector3 m_AccForce;


	// Use this for initialization
	void Start () {
		m_Animator = GetComponent<Animator>();
		m_Rigidbody = GetComponent<Rigidbody>();
		m_Capsule = GetComponent<CapsuleCollider>();
		m_CapsuleHeight = m_Capsule.height;
		m_CapsuleCenter = m_Capsule.center;

		m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
	}

	public void move(Vector3 move,bool accel){


		if (move.magnitude > 1f) move.Normalize();
		//move = transform.InverseTransformDirection(move);
		m_TurnAmount = Mathf.Atan2(move.x, move.z);

		if (accel) {
			m_ForwardAmount = 2f;
		} 
		else {
			m_ForwardAmount = 0f;
		}
		ApplyExtraTurnRotation();

		transform.position = new Vector3 (transform.position.x, transform.position.y + ( move.y*Time.deltaTime), transform.position.z + (m_ForwardAmount*Time.deltaTime));
		UpdateAnimator(move);
	}
	// Update is called once per frame
	void Update () {
				
	}

	void UpdateAnimator(Vector3 move){
		
		m_Animator.SetFloat("Forward", m_ForwardAmount, 0.1f, Time.deltaTime);
		m_Animator.SetFloat("Turn", m_TurnAmount, 0.1f, Time.deltaTime);

	}

	void ApplyExtraTurnRotation()
	{
		// help the character turn faster (this is in addition to root rotation in the animation)
		float turnSpeed = Mathf.Lerp(m_StationaryTurnSpeed, m_MovingTurnSpeed, m_ForwardAmount);
		transform.Rotate(0, m_TurnAmount * turnSpeed * Time.deltaTime, 0);
	}
}
