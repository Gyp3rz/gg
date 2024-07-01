using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] Volume v;
    public void Toggle()
    {
        if (menu.activeInHierarchy)
        {
            menu.SetActive(false);
            Time.timeScale = 1;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            UnityEngine.Rendering.Universal.DepthOfField field;
            v.profile.TryGet(out field);
            field.active = false;
        }
        else
        {
            menu.SetActive(true);
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            UnityEngine.Rendering.Universal.DepthOfField field;
            v.profile.TryGet(out field);
            field.active = true;
        }
    }
}
