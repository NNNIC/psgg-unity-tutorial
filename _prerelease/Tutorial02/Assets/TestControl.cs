using UnityEngine;
public partial class TestControl  {
		
	// write your code 

	void create_cube()
	{
		GameObject.CreatePrimitive(PrimitiveType.Cube);

	}

	int m_val;
	void set_zero_or_one()
	{
		m_val = Random.Range(0,2);
	}

	void br_zero(System.Action<bool> st)
	{
		if (m_val == 0)
		{
			SetNextState(st);
		}
	}
	void br_one(System.Action<bool> st)
	{
		if (m_val == 1)
		{
			SetNextState(st);
		}
	}

	void create_sphere()
	{
		var go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		go.transform.position = Vector3.up;
	}
	void create_cylinder()
	{
		var go = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
		go.transform.position = Vector3.up;
	}
}
