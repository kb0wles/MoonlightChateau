using UnityEngine;
using UnityEngine.InputSystem;
public class GMtester : MonoBehaviour
{
    private void Update()
    {
        if(Keyboard.current.wKey.wasPressedThisFrame)
        {
            GameManager.Instance.Win();
        }
        if (Keyboard.current.lKey.wasPressedThisFrame)
        {
            GameManager.Instance.Lose();
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
