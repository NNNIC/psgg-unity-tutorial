using UnityEngine;
using System.Collections;
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

	GameObject m_go;
	void create_sphere()
	{
		m_go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		m_go.transform.position = Vector3.up;
	}
	void create_cylinder()
	{
		m_go = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
		m_go.transform.position = Vector3.up;
	}

	bool m_bMoveDone;
	void move_obj(float x, float y, float z, float t)
	{
		var start = m_go.transform.position;
		var goal  = new Vector3(x,y,z);
		var steps = (int)(30 * t); 
		m_bMoveDone = false;
		Test.V.StartCoroutine(move_obj_co(start,goal,steps));
	}
	IEnumerator move_obj_co(Vector3 start, Vector3 goal, int steps )
	{
		for(var i = 0; i < steps; i++)
		{
			m_go.transform.position = Vector3.Slerp(start,goal, (float)i/steps);
			yield return null;
		}
		m_go.transform.position = goal;
		m_bMoveDone = true;
	}
	bool move_is_done()
	{
		return m_bMoveDone;
	}
}
