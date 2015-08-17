using UnityEngine;
using System.Collections;

//responsible for moving the car
//selfrights for stabilization
//has a target position it tries to stay at
//modify  that to make car move


public class RPGCar : MonoBehaviour 
{
	Rigidbody rb;
	//reference to empty gameobject to orient rotation on
	public Transform vReference;
	//speed with which car moves position
	public float thrust = 2000f;
	//speed at which car rotates position
	public float rotateSpeed = 0.001f;
	//speed at which car turns
	public float turnSpeed = 10f;
	//target position
	public float TargetX = 0f;
	public float TargetY = 0f;
	//distance the car is allowed to deviate
	public float Deviation = 2f;
	//area in which the car can move
	public float SpaceX = 100f;
	public float SpaceY = 100f;

	[SerializeField] private WheelCollider[] m_WheelColliders = new WheelCollider[4];
	[SerializeField] private GameObject[] m_WheelMeshes = new GameObject[4];

	void Start () 
	{
		rb = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate() 
	{
		//update wheel positions
		for (int i = 0; i < 4; i++)
		{
			Quaternion quat;
			Vector3 position;
			m_WheelColliders[i].GetWorldPose(out position, out quat);
			m_WheelMeshes[i].transform.position = position;
			m_WheelMeshes[i].transform.rotation = quat;
			//Debug.Log("ye");
		}
		
		SelfRight();
		
		if(transform.position.z < TargetY-Deviation)
		{
			Accelerate();
		}
		if(transform.position.z > TargetY-Deviation)
		{
			Brake();
		}
		if(transform.position.x < TargetX-Deviation)
		{
			MoveRight();
		}
		if(transform.position.x > TargetX+Deviation)
		{
			MoveLeft();
		}
	}
	public void SelfRight()
	{
		
		transform.rotation = Quaternion.Slerp(transform.rotation, vReference.rotation, Time.deltaTime * rotateSpeed); 
	}
	public void MoveTo(float a, float b)
	{
		if(a > -SpaceX && a < SpaceX)
		{TargetX = a;}
		
		if(b > -SpaceY && b < SpaceY)
		{TargetY = b;}
	}
	public void Accelerate()
	{
		rb.AddForce(transform.forward * thrust);
	}
	public void Brake()
	{
		rb.AddForce(-transform.forward * thrust);
	}
	public void MoveRight()
	{
		rb.AddForce(transform.right * thrust);
		/*m_WheelColliders[0].steerAngle = turnSpeed;
		m_WheelColliders[1].steerAngle = turnSpeed;
		rb.MovePosition(transform.position + transform.right * Time.deltaTime);*/
	}
	public void MoveLeft()
	{
		rb.AddForce(-transform.right * thrust);
		/*m_WheelColliders[0].steerAngle = -1 * turnSpeed;
		m_WheelColliders[1].steerAngle = -1 * turnSpeed;
		rb.MovePosition(transform.position + -transform.right * Time.deltaTime);*/
	}
	public void Break()
	{
		rb.AddForce(-transform.forward * thrust);
	}
}
