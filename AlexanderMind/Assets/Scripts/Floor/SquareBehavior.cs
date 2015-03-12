using UnityEngine;
using System.Collections;

public class SquareBehavior : MonoBehaviour 
    
{
    public Texture2D _textNormal;
    public Texture2D _textLeft;
    public Texture2D _textRight;
    public Texture2D _textStop;

    private Material _materialSquare;

	// Use this for initialization
	void Start () 
	{
	    _materialSquare.SetTexture()
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

    public void ChangeState(ListOrder.ModifiedSquare.TypeModification newState) //In case of performance trouble, add a check of actual state
	{
        if (newState == ListOrder.ModifiedSquare.TypeModification.MoveLeft)
        {

        }
	}
}
