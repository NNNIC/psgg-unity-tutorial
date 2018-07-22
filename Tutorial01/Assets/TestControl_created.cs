// psggConverterLib.dll converted from TestControl.xlsx. 
public partial class TestControl : StateManager {

    public void Start()
    {
        Goto(S_START);
    }


    /*
        S_START
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
            SetNextState(S_END);
        }
        if (HasNextState())
        {
            GoNextState();
        }
    }

}

