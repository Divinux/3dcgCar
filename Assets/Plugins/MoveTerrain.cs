using UnityEngine;
using System.Collections;

public class MoveTerrain : MonoBehaviour 
{

	public float vSpeed = 20f;
	
	bool SpawnedNew = false;
	public Rigidbody rb;
	void Start() 
	{
		rb = GetComponent<Rigidbody>();
	}
	void FixedUpdate() 
	{
		rb.MovePosition(transform.position + -transform.forward * Time.deltaTime * vSpeed);
		if(transform.position.z <= -100 && !SpawnedNew)
		{
			GameObject a = Instantiate(gameObject, new Vector3(transform.position.x,transform.position.y,transform.position.z+800), transform.rotation) as GameObject;
			a.name = "TerrainSpawned";
			SpawnedNew = true;
		}
		if(transform.position.z <= -800)
		{
			Destroy(gameObject);
		}
	}
}
