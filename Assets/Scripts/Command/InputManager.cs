using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private Button up;
    [SerializeField]
    private Button down;
    [SerializeField]
    private Button left;
    [SerializeField]
    private Button right;

   /* [SerializeField]
    private Button undo;
    [SerializeField]
    private Button redo;*/


    /// <summary>
    /// findobjectoftype yapısıyla dontdestroyonloadta null reference exception hatası alınması engellendi.
    /// </summary>

    //[SerializeField]
    private CharacterMove character;
    //[SerializeField]
    private CharacterMoveUndo characterUndo;
    [SerializeField]
    UICommandList uiCommandList;
    [SerializeField]
    CharacterMoveClean characterCleanMove;

    public bool is_Moving, is_Up, is_Down, is_Left, isRight;

    private void Awake()
    {
        is_Moving = false;
        character = FindObjectOfType<CharacterMove>();
        characterUndo = FindObjectOfType<CharacterMoveUndo>();
    }

    private void OnEnable()
    {
        up?.onClick.AddListener(() => SendMoveCommand(character.transform, Vector3.forward, 1f));
        down?.onClick.AddListener(() => SendMoveCommand(character.transform, Vector3.back, 1f));
        left?.onClick.AddListener(() => SendMoveCommand(character.transform, Vector3.left, 1f));
        right?.onClick.AddListener(() => SendMoveCommand(character.transform, Vector3.right, 1f));

        /*undo?.onClick.AddListener(() => character.UndoCommand());
        redo?.onClick.AddListener(() => character.RedoCommand());*/
    }

    private void Update()
    {
        //Keyboard Controller
        //It works when game is not stop

        if (FindObjectOfType<CollisionDetection>().game_is_Stop == false)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                is_Moving = true;
                is_Up = true;
                is_Down = false;
                isRight = false;
                is_Left = false;

                SendMoveCommand(character.transform, Vector3.forward, 1f);
                CameraShake.Instance.DoShake();
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                is_Moving = true;
                is_Up = false;
                is_Down = true;
                isRight = false;
                is_Left = false;

                SendMoveCommand(character.transform, Vector3.back, 1f);
                CameraShake.Instance.DoShake();
            }

            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                is_Moving = true;
                is_Up = false;
                is_Down = false;
                isRight = false;
                is_Left = true;

                SendMoveCommand(character.transform, Vector3.left, 1f);
                CameraShake.Instance.DoShake();
            }

            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                is_Moving = true;
                is_Up = false;
                is_Down = false;
                isRight = true;
                is_Left = false;

                SendMoveCommand(character.transform, Vector3.right, 1f);
                CameraShake.Instance.DoShake();
            }

            else
            {
                is_Moving = false;
                is_Up = false;
                is_Down = false;
                isRight = false;
                is_Left = false;
            }
        }

    }

    private void SendMoveCommand(Transform objectToMove, Vector3 direction, float distance)
    {
        ICommand movement = new Move(objectToMove, direction, distance);
        character.AddCommand(movement as Move);
        uiCommandList?.AddCommand(movement);
    }
}
