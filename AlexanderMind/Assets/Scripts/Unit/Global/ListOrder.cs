using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ListOrder : MonoBehaviour 
{
    public class ModifiedSquare
    {
        public enum TypeModification{None,MoveLeft,MoveRight,MoveTop,MoveBottom,SpecialAbilitie,Stop};
        public SquareBehavior _square = null;
        public TypeModification _modifOnSquare; //not on square because typemodif is associate to a unit, not a square

        public ModifiedSquare(TypeModification typeModif, SquareBehavior squareToAdd) //Constructor
        {
            _square = squareToAdd;
            _modifOnSquare = typeModif;
            _square.ChangeState(typeModif);
        }
    }

    List<ModifiedSquare> _listSquareModified = new List<ModifiedSquare>();
    

    public void ListOrderUnselected() //call when unit is selected
    {
        foreach (ModifiedSquare squareModif in _listSquareModified)
        {
            squareModif._square.ChangeState(ModifiedSquare.TypeModification.None);
        }
    }

    public void ListOrderSelected() //Call when unit is unselected
    {
        foreach (ModifiedSquare squareModif in _listSquareModified)
        {
            squareModif._square.ChangeState(squareModif._modifOnSquare);
        }
    }

    public ModifiedSquare.TypeModification ReturnModfiOfSquare(SquareBehavior square)
    {
        ModifiedSquare.TypeModification TypeModifToReturn = ModifiedSquare.TypeModification.None;

        foreach (ModifiedSquare element in _listSquareModified)
        {
            if (element._square == square)
            {
                TypeModifToReturn = element._modifOnSquare;
            }
        }
        return TypeModifToReturn;
    }

    public void AddNewSquareToList(ModifiedSquare.TypeModification typeModif, SquareBehavior squareToAdd)
    {
        RemoveSquareFromList(squareToAdd); //remove object if it is already in list
        ModifiedSquare objectToAdd = new ModifiedSquare(typeModif, squareToAdd);
        _listSquareModified.Add(objectToAdd);
    }

    public void RemoveSquareFromList(SquareBehavior _squareToRemove)
    {
        bool toRemove = false;
        ModifiedSquare elementToRemove = null ;

        foreach (ModifiedSquare element in _listSquareModified)
        {
            if (element._square == _squareToRemove)
            {
                elementToRemove = element;
                toRemove = true;
            }
        }

        if (toRemove)
        {
            _listSquareModified.Remove(elementToRemove);
        }
    }


    bool IsElementInList(SquareBehavior element)
    {
        bool toReturn = false;

        foreach (ModifiedSquare square in _listSquareModified)
        {
            if (square._square == element)
            {
                toReturn = true;
            }
        }

        return toReturn;
    }
}
