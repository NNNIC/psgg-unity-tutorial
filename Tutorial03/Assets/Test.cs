using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	public static Test V;

	TestControl m_sm;

	// Use this for initialization
	void Start () {
		V = this;
		m_sm = new TestControl();
		m_sm.Start();
	}
	
	// Update is called once per frame
	void Update () {
		m_sm.update();		
	}
}
