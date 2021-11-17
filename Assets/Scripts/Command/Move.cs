
using UnityEngine;

[System.Serializable]

public class Move : ICommand
{
    [SerializeField]
    private Vector3 direction = Vector3.zero;
    private Transform objectToMove;
    private float distance;

    public Move(Transform _objectToMove, Vector3 _direction, float _distance = 1f)
    {
        this.direction = _direction;
        this.objectToMove = _objectToMove;
        this.distance = _distance;
    }

    public void Execute()
    {
        objectToMove.position += direction * distance;
    }

    //Bunu ileride çıkarabiliriz.
    public void Undo()
    {
        objectToMove.position -= direction * distance;
    }

    public Vector3 GetMove()
    {
        return direction * distance;
    }
}
