using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[SerializeField]
public class ListOrder  
{
    public List<SquareBehavior> _listSquareInOrder = new List<SquareBehavior>(); 
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

    public void AddSquareToList(SquareBehavior objectToAdd)
	{
		_listSquareInOrder.Add(objectToAdd);
        objectToAdd.ChangeState(SquareBehavior.StateSquare.Selected);
	}

    public bool IsLastElement(SquareBehavior squareToCompare)
	{
		if (squareToCompare == ReturnLastSquare())
		{
			return true;
		}
		else
		{
			return false;
		}
	}

    public void UnselecAllSquare()
    {
        foreach (SquareBehavior square in _listSquareInOrder)
        {
            square.ChangeState(SquareBehavior.StateSquare.None);
        }
    }

	public int ReturnNbElementInList()
	{
		return _listSquareInOrder.Count;
	}

	public void RemoveFirstElement()
	{
        _listSquareInOrder[0].ChangeState(SquareBehavior.StateSquare.None);
		_listSquareInOrder.RemoveAt(0);
	}


    SquareBehavior ReturnLastSquare()
	{
		return _listSquareInOrder[_listSquareInOrder.Count - 1];
	}
}
