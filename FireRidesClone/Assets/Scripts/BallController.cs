using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{

	private LineRenderer lr;
	private Vector3 grapplePoint;
	public Transform ballGrapplePoint, player;
	private float maxDistance = 100f;
	private SpringJoint joint;
	private Rigidbody rb;

	private void Awake()
	{
		lr = GetComponent<LineRenderer>();
		rb = GetComponent <Rigidbody>();
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			StartGrapple();
		}
		else if (Input.GetMouseButtonUp(0))
		{
			StopGrapple();
		}
	}


	void LateUpdate()
	{
		DrawRope();
	}

	void StartGrapple()
	{
		LayerMask mask = ~(1 << 15); //Ignore layer 15
		RaycastHit hit;
		if (Physics.Raycast(ballGrapplePoint.position, new Vector3(6, 10), out hit, maxDistance, mask))
		{
			grapplePoint = hit.point;
			joint = player.gameObject.AddComponent<SpringJoint>();
			joint.autoConfigureConnectedAnchor = false;
			joint.connectedAnchor = grapplePoint;

			float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);

			joint.maxDistance = distanceFromPoint * 0.8f;
			joint.minDistance = distanceFromPoint * 0.25f;

			joint.spring = 4.5f;
			joint.damper = 7f;
			joint.massScale = 4.5f;

			lr.positionCount = 2;

			rb.AddForce(new Vector3(85,0,0));
			rb.AddForce(new Vector3(0, 45, 0));
		}
	}


	void DrawRope()
	{
		if (!joint) return;
		lr.SetPosition(0, ballGrapplePoint.position);
		lr.SetPosition(1, grapplePoint);

	}

	void StopGrapple()
	{
		lr.positionCount = 0;
		Destroy(joint);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "BigCircle")
		{
			GameManager.Instance.score += 25;
		}
		else if (other.gameObject.tag == "SmallCircle")
		{
			GameManager.Instance.score += 100;
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "GameOver")
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}

}
