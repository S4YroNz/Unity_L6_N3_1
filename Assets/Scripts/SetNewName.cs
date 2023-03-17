using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetNewName : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private TMP_InputField _inputField;

    public void SetName()
    {
        _text.text = _inputField.text;
    }
}
