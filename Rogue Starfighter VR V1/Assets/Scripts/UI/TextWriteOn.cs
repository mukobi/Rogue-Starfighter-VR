using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class TextWriteOn : MonoBehaviour
{
    private TextMeshProUGUI textMesh = default;

    [SerializeField] private float characterWriteOnIntervalSeconds = default;

    public UnityEvent OnCharacterWritten;

    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        textMesh.text = "";
    }

    public void WriteOnText(string text)
    {
        StartCoroutine(WriteOnTextCoroutine(text));
    }

    private IEnumerator WriteOnTextCoroutine(string text)
    {
        textMesh.text = text;
        for (int i = 0; i < text.Length; i++)
        {
            textMesh.maxVisibleCharacters = i;
            OnCharacterWritten.Invoke();
            yield return new WaitForSeconds(characterWriteOnIntervalSeconds);
        }
    }

    public void WriteOffText()
    {
        StartCoroutine(WriteOffTextCoroutine());
    }

    private IEnumerator WriteOffTextCoroutine()
    {
        for (int i = textMesh.text.Length - 1; i >= 0; i--)
        {
            textMesh.maxVisibleCharacters = i;
            OnCharacterWritten.Invoke();
            yield return new WaitForSeconds(characterWriteOnIntervalSeconds);
        }
        textMesh.text = "";
    }
}
