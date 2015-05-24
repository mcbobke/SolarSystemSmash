using UnityEngine;
using System.Collections;

public class ToMainMenu : MonoBehaviour
{
    private void OnMouseDown()
    {
        Application.LoadLevel("Nick's Main Menu Test");
    }
}
