// psggConverterLib.dll converted from TestControl.xlsx. 
using UnityEngine;
public partial class TestControl : StateManager {

    public void Start()
    {
        Goto(S_START);
    }


    /*
        S_START
        開始
    */
    void S_START(bool bFirst)
    {
        if (bFirst)
        {
        }
        if (!HasNextState())
        {
            SetNextState(S_CREATE_CUBE);
        }
        if (HasNextState())
        {
            GoNextState();
        }
    }
    /*
        S_END
        終了
    */
    void S_END(bool bFirst)
    {
        if (bFirst)
        {
        }
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
            create_cube();
        }
        if (!HasNextState())
        {
            SetNextState(S_SELECT);
        }
        if (HasNextState())
        {
            GoNextState();
        }
    }
    /*
        S_SELECT
        乱数で０か１を取得
    */
    void S_SELECT(bool bFirst)
    {
        if (bFirst)
        {
            set_0or1();
        }
        br_0(S_CREATE_SPHERE);
        br_1(S_CREATE_SYLINDER);
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
            create_sphere();
        }
        if (!HasNextState())
        {
            SetNextState(S_MOVE);
        }
        if (HasNextState())
        {
            GoNextState();
        }
    }
    /*
        S_CREATE_SYLINDER
        シリンダー作成
    */
    void S_CREATE_SYLINDER(bool bFirst)
    {
        if (bFirst)
        {
            create_cylinder();
        }
        if (!HasNextState())
        {
            SetNextState(S_MOVE);
        }
        if (HasNextState())
        {
            GoNextState();
        }
    }
    /*
        S_MOVE
        new state
    */
    void S_MOVE(bool bFirst)
    {
        if (bFirst)
        {
            var pos = new Vector3(5,7,0);
            move_start(pos,5);
        }
        if (!move_isdone()) return;
        if (!HasNextState())
        {
            SetNextState(S_END);
        }
        if (HasNextState())
        {
            GoNextState();
        }
    }

}

