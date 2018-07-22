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
            SetNextState(S_BRANCH);
        }
        if (HasNextState())
        {
            GoNextState();
        }
    }
    /*
        S_BRANCH
        分岐する
    */
    void S_BRANCH(bool bFirst)
    {
        if (bFirst)
        {
            set_zero_or_one();
        }
        br_zero(S_CREATE_SPHERE);
        br_one(S_CREATE_CYLINDER);
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
        移動
    */
    void S_MOVE(bool bFirst)
    {
        if (bFirst)
        {
            move_obj(5,5,5,10);
        }
        if (!move_is_done()) return;
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

}

