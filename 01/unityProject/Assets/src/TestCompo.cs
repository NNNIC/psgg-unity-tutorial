﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCompo : MonoBehaviour {

    TestControl m_tc;

	// Use this for initialization
	void Start () {
		m_tc = new TestControl();
        m_tc.Start();
	}
	
	// Update is called once per frame
	void Update () {
		m_tc.update();
	}
}