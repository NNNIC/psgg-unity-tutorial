using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class TestControl : MonoBehaviour {
 
    #region manager
    Action<bool> m_curfunc;
    Action<bool> m_nextfunc;

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
    bool HasNextState()
    {
        return m_nextfunc != null;
    }
    void NoWait()
    {
        m_noWait = true;
    }
    #endregion
    #region gosub
    List<Action<bool>> m_callstack = new List<Action<bool>>();
    void GoSubState(Action<bool> nextstate, Action<bool> returnstate)
    {
        m_callstack.Insert(0,returnstate);
        Goto(nextstate);
    }
    void ReturnState()
    {
        var nextstate = m_callstack[0];
        m_callstack.RemoveAt(0);
        Goto(nextstate);
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

	#region    // [PSGG OUTPUT START] indent(4) $/./$
    //             psggConverterLib.dll converted from psgg-file:TestControl.psgg

    /*
        S_1st
    */
    void S_1st(bool bFirst)
    {
        var o = new GameObject();
        o.AddComponent<TextMesh>().text = "You are 1st";
        o.transform.position = Vector3.down;
        //
        if (!HasNextState())
        {
            Goto(S_END);
        }
    }
    /*
        S_1st3
    */
    void S_1st3(bool bFirst)
    {
        var o = new GameObject();
        
o.AddComponent<TextMesh>().text = string.Format("You are {0}th",m_val);
        
o.transform.position = Vector3.down;
        //
        if (!HasNextState())
        {
            Goto(S_END);
        }
    }
    /*
        S_2nd
    */
    void S_2nd(bool bFirst)
    {
        var o = new GameObject();
        o.AddComponent<TextMesh>().text = "You are 2nd";
        o.transform.position = Vector3.down;
        //
        if (!HasNextState())
        {
            Goto(S_END);
        }
    }
    /*
        S_3rd
    */
    void S_3rd(bool bFirst)
    {
        var o = new GameObject();
        o.AddComponent<TextMesh>().text = "You are 3rd";
        o.transform.position = Vector3.down;
        //
        if (!HasNextState())
        {
            Goto(S_END);
        }
    }
    /*
        S_END
    */
    void S_END(bool bFirst)
    {
    }
    /*
        S_GET_RAND
        １から１０までの乱数取得
    */
    int m_val = 0;
    void S_GET_RAND(bool bFirst)
    {
        m_val = rand(1,10);
        // branch
        if (m_val == 1) { Goto( S_1st ); }
        else if (m_val == 2) { Goto( S_2nd ); }
        else if (m_val == 3) { Goto( S_3rd ); }
        else { Goto( S_1st3 ); }
    }
    /*
        S_HELLOWORLD
        定番のHello Worldを表示
    */
    void S_HELLOWORLD(bool bFirst)
    {
        gameObject.AddComponent<TextMesh>().text = "Hello World";
        //
        if (!HasNextState())
        {
            Goto(S_GET_RAND);
        }
    }
    /*
        S_START
    */
    void S_START(bool bFirst)
    {
        Goto(S_HELLOWORLD);
        NoWait();
    }


	#endregion // [PSGG OUTPUT END]

	int rand(int x, int y)
    {
        var r = UnityEngine.Random.Range(x,y+1);
        return r;
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

/*  :::: PSGG MACRO ::::
:psgg-macro-start

commentline=// {%0}

@branch=@@@
<<<?"{%0}"/^brifc{0,1}$/
if ([[brcond:{%N}]]) { Goto( {%1} ); }
>>>
<<<?"{%0}"/^brelseifc{0,1}$/
else if ([[brcond:{%N}]]) { Goto( {%1} ); }
>>>
<<<?"{%0}"/^brelse$/
else { Goto( {%1} ); }
>>>
<<<?"{%0}"/^br_/
{%0}({%1});
>>>
@@@

:psgg-macro-end
*/

