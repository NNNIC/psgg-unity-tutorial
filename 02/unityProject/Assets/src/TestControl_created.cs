// psggConverterLib.dll converted from TestControl.xlsx. 
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
            SetNextState(S_0001);
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
        S_0001
        new state
    */
    void S_0001(bool bFirst)
    {
        if (bFirst)
        {
            create_cube();
        }
        if (!HasNextState())
        {
            SetNextState(S_0002);
        }
        if (HasNextState())
        {
            GoNextState();
        }
    }
    /*
        S_0002
        new state
    */
    void S_0002(bool bFirst)
    {
        if (bFirst)
        {
            set_0or1();
        }
        br_0(S_0003);
        br_1(S_0004);
        if (HasNextState())
        {
            GoNextState();
        }
    }
    /*
        S_0003
        new state
    */
    void S_0003(bool bFirst)
    {
        if (bFirst)
        {
            create_sphere();
        }
        if (!HasNextState())
        {
            SetNextState(S_END);
        }
        if (HasNextState())
        {
            GoNextState();
        }
    }
    /*
        S_0004
        new state
    */
    void S_0004(bool bFirst)
    {
        if (bFirst)
        {
            create_cylinder();
        }
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

