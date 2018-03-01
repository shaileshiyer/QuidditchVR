using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class UserControlScript : MonoBehaviour {
	private BroomPlayerCharacter m_BroomPlayer;						//A reference to the current player	
	private Transform m_Cam;                  // A reference to the main camera in the scenes transform
	private Vector3 m_CamForward;             // The current forward direction of the camera
	private Vector3 m_Move;
	private bool m_Acc;
	// Use this for initialization
	private void Start () {

		if (Camera.main != null) {
			m_Cam = Camera.main.transform;
		} 
		else {
			Debug.LogWarning ("No Main Camera attached Broom player needs a camera component for camera related controls", gameObject);
		}
		m_BroomPlayer = GetComponent<BroomPlayerCharacter>();
	}
	
	// Update is called once per frame

	private void Update (){
		float h = CrossPlatformInputManager.GetAxis("Horizontal");
		float v = CrossPlatformInputManager.GetAxis ("Vertical");
		m_Acc = Input.GetButtonDown("Acceleration");

		if (m_Cam != null)
		{
			// calculate camera relative direction to move:
			m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(0, 1, 1)).normalized;
			m_Move = v*m_CamForward + h*m_Cam.right;
		}
		else
		{
			// we use world-relative directions in the case of no main camera
			m_Move = v*Vector3.up + h*Vector3.right;
		}

		m_BroomPlayer.move(m_Move,m_Acc);
	}


}
