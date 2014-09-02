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
			float shootForce = 5f;
			float spawnDistance = 0.6f;
			Rigidbody bullet = Instantiate(bulletPrefab,
			                               transform.position + spawnDistance * transform.forward,
			                               transform.rotation) as Rigidbody;
			bullet.AddForce(bullet.transform.forward * shootForce, ForceMode.Impulse);
	  }
	}

	void OnCollisionEnter(Collision collision) {

	}
}
