using UnityEngine;
using System.Collections;

public class CameraPositionScript : MonoBehaviour 
{
	public float minHeight = 5f;
	public float maxHeight = 30f;

	Transform player;
	float cameraHeight = 17f;
	
	void Awake ()
	{
		player = GameObject.Find("Player").transform;
	}

	void LateUpdate ()
	{
		ScrollFromMouse ();
		FollowUser ();
	} 

	void ScrollFromMouse()
	{
		float cameraMove = CrossPlatformInput.GetAxis("Mouse ScrollWheel");
		if (cameraMove != 0)
		{
			if ((cameraHeight < maxHeight || cameraMove < 0) && (cameraHeight > minHeight || cameraMove > 0))
			{
				float speed = 100f;
				cameraHeight = cameraHeight + cameraMove * speed * Time.smoothDeltaTime;
			}

		}
	}

	void FollowUser()
	{
			float speed = 5f;
//		
//				float xTarget = player.position.x;
//				float yTarget = player.position.y + cameraHeight;
//				float zTarget = player.position.z;
//				
//				transform.position = new Vector3 (xTarget, yTarget, zTarget);
//		
		//		float xPositionModifier = 0f;
		//		float zPositionModifier = 0f;
		//
		//		float xPositionDifference = transform.position.x - player.position.x;
		//		float yPositionDifference = (transform.position.y + cameraHeight) - player.position.y;
		//		float zPositionDifference = transform.position.z - player.position.z;
		//
		//		float positionDifferenceTreshold = 1.5f;
		
		//		if (xPositionDifference > 0) {
		//			xPositionModifier = Mathf.Min(positionDifferenceTreshold, xPositionDifference);
		//		}
		//		else if (xPositionDifference < 0)
		//		{
		//			xPositionModifier = Mathf.Max(-positionDifferenceTreshold, xPositionDifference);
		//		}
		//
		//		if (zPositionDifference > 0) {
		//			zPositionModifier = Mathf.Min(positionDifferenceTreshold, zPositionDifference);
		//		}
		//		else if (xPositionDifference < 0)
		//		{
		//			zPositionModifier = Mathf.Max(-positionDifferenceTreshold, zPositionDifference);
		//		}
		
		
		
		//		float xTarget = Mathf.Lerp (transform.position.x, player.position.x + xPositionModifier, speed * Time.smoothDeltaTime);
		//		float yTarget = Mathf.Lerp (transform.position.y, player.position.y + cameraHeight, speed * Time.smoothDeltaTime);
		//		float zTarget = Mathf.Lerp (transform.position.z, player.position.z + zPositionModifier, speed * Time.smoothDeltaTime);
		
		//		float xTarget = player.position.x + xPositionModifier;
		//		float yTarget = player.position.y + cameraHeight;
		//		float zTarget = player.position.z + zPositionModifier;
		
		
		//		Vector3 zero = Vector3.zero;
		//		transform.position = Vector3.SmoothDamp(transform.position, new Vector3 (xTarget, yTarget, zTarget), ref zero, 1f * Time.deltaTime);
		//		transform.position = Vector3.MoveTowards(transform.position, new Vector3 (xTarget, yTarget, zTarget), speed * Time.deltaTime);
		//		transform.position = new Vector3 (xTarget, yTarget, zTarget);
		
		//		float speed2 = 10f;
		
		float xTarget = player.position.x;
		float yTarget = player.position.y + cameraHeight;
		float zTarget = player.position.z;
		//		
		transform.position = Vector3.MoveTowards(transform.position, new Vector3 (xTarget, yTarget, zTarget), speed * Time.deltaTime);
		
		//		rigidbody.velocity = new Vector3 (xVelocity, rigidbody.velocity.y, zVelocity);
		
		//		float xVelocity = (xPositionDifference * (-1f) * Time.smoothDeltaTime) + transform.position.x;
		//		float yVelocity = (yPositionDifference * (-1f) * Time.smoothDeltaTime) + transform.position.y;
		//		float zVelocity = (zPositionDifference * (-1f) * Time.smoothDeltaTime) + transform.position.z;
		//
		//		rigidbody.velocity = new Vector3 (xVelocity, yVelocity, zVelocity);
	}
}
