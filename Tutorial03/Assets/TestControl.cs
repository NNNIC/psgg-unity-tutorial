using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class TestControl : MonoBehaviour {
 
    #region manger
    Action<bool> m_curfunc;
    Action<bool> m_nextfunc;
    Action<bool> m_tempfunc;

    bool         m_noWait;
    
    void _update()
    {
        while(true)
        {
            var bFirst = false;
            if (m_nextfunc!=null)
            {
                m_curfunc = m_nextfunc;
                m_nextfunc = null;
                bFirst = true;
            }
            m_noWait = false;
            if (m_curfunc!=null)
            {   
                m_curfunc(bFirst);
            }
            if (!m_noWait) break;
        }
    }
    void Goto(Action<bool> func)
    {
        m_nextfunc = func;
    }
    bool CheckState(Action<bool> func)
    {
        return m_curfunc == func;
    }
    // for tempfunc
    void SetNextState(Action<bool> func)
    {
        m_tempfunc = func;
    }
    void GoNextState()
    {
        m_nextfunc = m_tempfunc;
        m_tempfunc = null;
    }
    bool HasNextState()
    {
        return m_tempfunc != null;
    }
    void NoWait()
    {
        m_noWait = true;
    }
    #endregion

    void _start()
    {
        Goto(S_START);
    }
    public bool IsEnd()     
    { 
        return CheckState(S_END); 
    }

	#region    // [SYN-G-GEN OUTPUT START] indent(8) $/./$
//  psggConverterLib.dll converted from TestControl.xlsx. 
        /*
            E_DEFOBJ
        */
        GameObject m_obj;
        /*
            S_BRANCH
            分岐する
        */
        void S_BRANCH(bool bFirst)
        {
            int x = 0;
            if (bFirst)
            {
                x = UnityEngine.Random.Range(0,2);
            }
            // branch
            if (x==0) { SetNextState( S_CREATE_SPHERE ); }
            else { SetNextState( S_CREATE_CYLINDER ); }
            //
            if (HasNextState())
            {
                GoNextState();
            }
        }
        /*
            S_CHANGEPOS
            位置変更
        */
        void S_CHANGEPOS(bool bFirst)
        {
            if (bFirst)
            {
                m_obj.transform.localPosition = Vector3.up;
            }
            //
            if (!HasNextState())
            {
                SetNextState(S_MOVE);
            }
            //
            if (HasNextState())
            {
                GoNextState();
            }
        }
        /*
            S_CREATE_CUBE
            キューブ作成
        */
        void S_CREATE_CUBE(bool bFirst)
        {
            if (bFirst)
            {
                GameObject.CreatePrimitive(PrimitiveType.Cube);
            }
            //
            if (!HasNextState())
            {
                SetNextState(S_BRANCH);
            }
            //
            if (HasNextState())
            {
                GoNextState();
            }
        }
        /*
            S_CREATE_CYLINDER
            シリンダー作成
        */
        void S_CREATE_CYLINDER(bool bFirst)
        {
            if (bFirst)
            {
                m_obj=GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            }
            //
            if (!HasNextState())
            {
                SetNextState(S_CHANGEPOS);
            }
            //
            if (HasNextState())
            {
                GoNextState();
            }
        }
        /*
            S_CREATE_SPHERE
            スフィア作成
        */
        void S_CREATE_SPHERE(bool bFirst)
        {
            if (bFirst)
            {
                m_obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            }
            //
            if (!HasNextState())
            {
                SetNextState(S_CHANGEPOS);
            }
            //
            if (HasNextState())
            {
                GoNextState();
            }
        }
        /*
            S_END
        */
        void S_END(bool bFirst)
        {
            //
            if (HasNextState())
            {
                GoNextState();
            }
        }
        /*
            S_MOVE
            移動
        */
        Vector3 m_start;
        Vector3 m_goal;
        float      m_time;
        float      m_elapsed;
        void S_MOVE(bool bFirst)
        {
            if (bFirst)
            {
                m_start = m_obj.transform.position;
                m_goal = new Vector3(5,5,5);
                m_time = 1;
                m_elapsed = 0;
            }
            m_elapsed += Time.deltaTime;
            var t = Mathf.Clamp01(m_elapsed / m_time);
            var pos = Vector3.Slerp(m_start,m_goal,t);
            m_obj.transform.position = pos;
            if (!(m_elapsed >= m_time)) return;
            //
            if (!HasNextState())
            {
                SetNextState(S_END);
            }
            //
            if (HasNextState())
            {
                GoNextState();
            }
        }
        /*
            S_START
        */
        void S_START(bool bFirst)
        {
            //
            if (!HasNextState())
            {
                SetNextState(S_CREATE_CUBE);
            }
            //
            if (HasNextState())
            {
                GoNextState();
            }
        }


	#endregion // [SYN-G-GEN OUTPUT END]

	// write your code below

	bool m_bYesNo;
	
	void br_YES(Action<bool> st)
	{
		if (!HasNextState())
		{
			if (m_bYesNo)
			{
				SetNextState(st);
			}
		}
	}

	void br_NO(Action<bool> st)
	{
		if (!HasNextState())
		{
			if (!m_bYesNo)
			{
				SetNextState(st);
			}
		}
	}

    #region Monobehaviour framework
    void Start()
    {
        _start();
    }
    void Update()
    {
        if (!IsEnd()) 
        {
            _update();
        }
    }
    #endregion
}