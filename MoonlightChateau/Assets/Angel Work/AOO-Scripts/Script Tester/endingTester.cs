using UnityEngine;
using UnityEngine.InputSystem;

public class endingTester : MonoBehaviour
{
    void Update()
    {
        if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            winCondition.Instance.WinCount();
        }

        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            winCondition.Instance.ChooseEndings();
        }

        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            winCondition.Instance.PickTrueEnding();
        }
    }
}
