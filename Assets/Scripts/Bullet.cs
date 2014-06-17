using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public Rigidbody bulletPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	  if (Input.GetButtonDown ("Fire1"))
	  {
			float shootForce = 100f;

			rigidbody.AddForce (new Vector3(1,2,3), ForceMode.Impulse);

			GameObject bullet = (GameObject) Instantiate(bulletPrefab, transform.position, transform.rotation);
//			rigidbody.addForce(new Vector3(Vector3.right, 0f, 0f), ForceMode.Impulse);
			bullet.rigidbody.addForce(new Vector3(1,2,3), ForceMode.Impulse);

	  }
	}
}
