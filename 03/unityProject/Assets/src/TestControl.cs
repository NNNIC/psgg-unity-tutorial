using System;
using System.Collections;
using UnityEngine;

public partial class TestControl  {
		
    GameObject m_obj;

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
        m_obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        m_obj.transform.position = Vector3.up * 2;
    }

    void create_cylinder()
    {
        m_obj = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        m_obj.transform.position = Vector3.up * 2;
    }

    bool m_move_done;
    void move_start(Vector3 pos, float time=1)
    {
        m_move_done = false;
        TestCompo.V.StartCoroutine(move_co(pos,time));
    }
    IEnumerator move_co(Vector3 goal, float time)
    {
        var start = m_obj.transform.position;
        var steps = (int)(time * 30);
        for(var i = 0; i<steps; i++)
        {
            var pos = Vector3.Slerp(start,goal,(float)i/steps);
            m_obj.transform.position = pos;
            yield return null;
        }
        m_obj.transform.position =goal;
        m_move_done = true;
    }
    bool move_isdone()
    {
        return m_move_done;
    }


    
}
