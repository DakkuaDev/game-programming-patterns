using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISubject : MonoBehaviour
{
    Scrollbar m_scrollbar;
    bool systemInitialiced = false;

    public TextMeshProUGUI UIPercentText;


    // Start is called before the first frame update
    void Start()
    {
        m_scrollbar = GetComponent<Scrollbar>();

        systemInitialiced = true;
    }

    private void OnEnable()
    {
        StartCoroutine(OnEnableIE());
    }

    private IEnumerator OnEnableIE()
    {
        Debug.Log("Inicializando Sistema Observer");
        yield return new WaitUntil(() => systemInitialiced == true);
        if (m_scrollbar != null)
        {
            m_scrollbar.onValueChanged.AddListener(OnValueChanged);
        }
        Debug.Log("Sistema Inicializado con Éxito");

    }

    private void OnDisable()
    {
        if (m_scrollbar != null)
        {
            m_scrollbar.onValueChanged.RemoveListener(OnValueChanged);
        }
    }

    private void OnValueChanged(float _value)
    {
        UIPercentText.text = "HP: " + _value.ToString();
    }
}
