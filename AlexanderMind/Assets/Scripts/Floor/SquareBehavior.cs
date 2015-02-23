﻿using UnityEngine;
using System.Collections;

public class SquareBehavior : MonoBehaviour 
{
	public enum StateSquare{None, Selected, UnitOnTop};
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void ChangeState(StateSquare newState) //In case of performance trouble, add a check of actual state
	{
        if (newState == StateSquare.None)
        {
            this.renderer.material.color = Color.white;
        }
		else if (newState == StateSquare.Selected)
        {
            this.renderer.material.color = Color.yellow;
        }
        else if (newState == StateSquare.UnitOnTop)
        {
            this.renderer.material.color = Color.red;
        }
	}
}