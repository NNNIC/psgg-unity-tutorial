using System;
using UnityEngine;

public partial class TestControl  {
		
	// write your code 

    void create_cube()
    {
        GameObject.CreatePrimitive(PrimitiveType.Cube);
    }

    int m_val;
    void set_0or1()
    {
        m_val = UnityEngine.Random.Range(0,2);
    }

    void br_0(Action<bool> st)
    {
        if (m_val == 0) SetNextState(st);
    }
    void br_1(Action<bool> st)
    {
        if (m_val == 1) SetNextState(st);
    }

    void create_sphere()
    {
        GameObject.CreatePrimitive(PrimitiveType.Sphere).transform.position = Vector3.up * 2;
    }

    void create_cylinder()
    {
        GameObject.CreatePrimitive(PrimitiveType.Cylinder).transform.position = Vector3.up * 2;
    }

}
