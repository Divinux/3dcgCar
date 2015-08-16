using UnityEngine; 
using System.Collections;

public class Stabilizer : MonoBehaviour {

	public float stability = 0.3f;
	public float speed = 2.0f;

	Rigidbody rb;
	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}
	// Update is called once per frame
	void FixedUpdate () 
	{
		Vector3 predictedUp = Quaternion.AngleAxis
		(
		rb.angularVelocity.magnitude * Mathf.Rad2Deg * stability / speed,
		rb.angularVelocity
		) * transform.up;

		Vector3 torqueVector = Vector3.Cross(predictedUp, Vector3.up);
		torqueVector = Vector3.Project(torqueVector, transform.up);
		rb.AddTorque(torqueVector * speed * speed * 100);
	}
}