using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainBtnCtrl : MonoBehaviour
{
    Color _originColor;

    public void ButtonDownMoveDown(RectTransform target)
    {
        target.anchoredPosition += Vector2.down * 9.0f;
    }
    public void ButtonUpMoveUp(RectTransform target)
    {
        target.anchoredPosition += Vector2.up * 9.0f;

        target.localScale = Vector3.one;
    }
    public void ButtonDownScaleRestore(RectTransform target)
    {
        target.localScale *= 0.9f;
    }
    public void StartBtnColor(Graphic target)
    {
        _originColor = target.color;
        target.color = new Color(255,100,0);
    }
    public void LobbyBtnColor(Graphic target)
    {
        _originColor = target.color;
        target.color = Color.white;
    }
    public void ButtonUpChangeOrigin(Graphic target)
    {
        target.color = _originColor;
    }
}
