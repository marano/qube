using UnityEngine;

public class Character : MonoBehaviour 
{	
	public float moveForce = 5f;
	float maxSpeed = 5f;

	void Update()
	{
	}

	void FixedUpdate()
	{
		lookTowardCursor ();
		moveFromInput ();
		handleJump ();
	}

	void moveFromInput() {
		float horizontalMove = CrossPlatformInput.GetAxis("Horizontal");
		float verticalMove = CrossPlatformInput.GetAxis("Vertical");

		float positiveHorizontalMove = horizontalMove < 0 ? horizontalMove * (-1) : horizontalMove;
		float positiveVerticalMove = verticalMove < 0 ? verticalMove * (-1) : verticalMove;

		float totalMovement = positiveHorizontalMove + positiveVerticalMove;

		float xForce = horizontalMove * (totalMovement == 0f ? 0.7071f : (positiveHorizontalMove / totalMovement)) * moveForce;
		float yForce = 0;
		float zForce = verticalMove * (totalMovement == 0f ? 0.7071f : (positiveVerticalMove / totalMovement)) * moveForce;

		if (xForce < 0 && rigidbody.velocity.x > 0) {
			rigidbody.velocity = new Vector3 (0f, rigidbody.velocity.y, rigidbody.velocity.z);
		}
		else if (xForce > 0 && rigidbody.velocity.x < 0)
		{
			rigidbody.velocity = new Vector3 (0f, rigidbody.velocity.y, rigidbody.velocity.z);
		}
		
		if (zForce < 0 && rigidbody.velocity.z > 0) {
			rigidbody.velocity = new Vector3 (rigidbody.velocity.x, rigidbody.velocity.y, 0f);
		}
		else if (zForce > 0 && rigidbody.velocity.z < 0)
		{
			rigidbody.velocity = new Vector3 (rigidbody.velocity.x, rigidbody.velocity.y, 0f);
		}

		if (rigidbody.velocity.x > maxSpeed || rigidbody.velocity.x < -maxSpeed) {
			xForce = 0;
		}
		
		if (rigidbody.velocity.z > maxSpeed || rigidbody.velocity.z < -maxSpeed) {
			zForce = 0;
		}

		rigidbody.AddForce (new Vector3(xForce, yForce, zForce), ForceMode.Impulse);
	}

	void handleJump()
	{
		float jumpForce = 10f;
		RaycastHit hit;
		Physics.Raycast (transform.position, transform.TransformDirection (Vector3.down), out hit, Mathf.Infinity);
		bool isGrounded = (hit.distance - ((gameObject.GetComponent<BoxCollider>().size.y / 2) + 0.5f)) <= 0f;

		if (isGrounded && Input.GetButtonDown("Jump")) {
			rigidbody.AddForce (new Vector3 (0, jumpForce, 0), ForceMode.Impulse);
		}
	}

	void lookTowardCursor()
	{
		float speed = 5f; 

		Plane playerPlane = new Plane(Vector3.up, transform.position);
		Ray cameraRay = Camera.main.ScreenPointToRay (Input.mousePosition);

		float distanceFromCameraToPlane;

		if (playerPlane.Raycast (cameraRay, out distanceFromCameraToPlane))
		{
			Vector3 targetPosition = cameraRay.GetPoint(distanceFromCameraToPlane);
			Quaternion targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
			transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.smoothDeltaTime);
		}
	}
}
