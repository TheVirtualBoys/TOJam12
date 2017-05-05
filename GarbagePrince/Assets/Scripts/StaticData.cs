using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticData : MonoBehaviour {

	private static StaticData staticData = null;

	void Start()
	{
		if (!staticData) {
			DontDestroyOnLoad(this);
			staticData = this;
		}
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}
}
