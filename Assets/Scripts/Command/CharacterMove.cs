using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    [SerializeField] private float y_axis;

    [SerializeField]
    private List<Move> commandList = new List<Move>();
    private int index;
    private Vector3 startPoint;
    private PathDraw pathDrawer;
    private float verticalOffset = 0.1f;

    #region path drawing
    //path drawing

    private void Awake()
    {
        gameObject.transform.DOMoveY(y_axis, 1f);
    }

    private void Start()
    {
        startPoint = this.transform.position;
        startPoint.y = verticalOffset;
        pathDrawer = this.GetComponent<PathDraw>();
    }
    #endregion

    public void AddCommand(Move command)
    {
        if (index < commandList.Count)
            commandList.RemoveRange(index, commandList.Count-index);

        commandList.Add(command);
        command.Execute();
        index++;

        UpdateLine();

        //Doscale işe yarıyor.
        gameObject.transform.DOScaleY(.6f, 0f).OnComplete(() => gameObject.transform.DOScaleY(.5f, .2f));
        StartCoroutine(doKill(1));

        //Ses ekleme.
        FindObjectOfType<AudioManager>().Play("Jump");

    }

    private IEnumerator doKill(float time)
    {
        yield return new WaitForSeconds(time);
        //gameObject.transform.DOKill();
        //Debug.Log("WASD");

    }

    public void UndoCommand()
    {
        if (commandList.Count == 0)
            return;
        if (index > 0)
        {
            commandList[index - 1].Undo();
            index--;
        }
        UpdateLine();
    }

    public void RedoCommand()
    {
        if (commandList.Count == 0)
            return;

        if (index < commandList.Count)
        {
            index++;
            commandList[index - 1].Execute();
        }
        UpdateLine();
    }

    public void UpdateLine()
    {
        if (pathDrawer == null)
            return;

        List<Vector3> positions = new List<Vector3>();
        positions.Add(startPoint);

        for (int i = 0; i < index; i++)
        {
            Vector3 newPosition = commandList[i].GetMove() + positions[i];
            newPosition.y = verticalOffset; // used to keep it near the ground
            positions.Add(newPosition);
        }

        pathDrawer.UpdateLine(positions);
    }

}
