using UnityEngine;
using UnityEngine.InputSystem;

public class WinTestDriver : MonoBehaviour
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

        if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            winCondition.Instance.PickFalseEnding();
        }
    }
}
