﻿using UnityEngine;
using VRKL.MBU;

/// <summary>
/// View für eine eine analoge Uhr
/// mit Stunden- und Minutenzeiger
/// </summary>
public class View : Observer
{
    /// <summary>
    /// Die Farbe dieses Materials wird für die geänderte Farbe verwendet.
    /// </summary>
    [Tooltip("Material für das Highlight")]
    public Material highlightMaterial;
    /// <summary>
    /// Möchten wir Log-Ausgaben in der Callback-Funktion?
    /// </summary>
    [Tooltip("Sollen ausgaben auf der Konsole gemacht werden?")]
    public bool logOutput = false;

    /// <summary>
    /// Model Klasse
    /// </summary>
    protected Model Mod;

    /// <summary>
    /// Variable, die das Original-Material des Objekts enthält
    /// </summary>
    protected Material myMaterial;

    /// <summary>
    /// Wir fragen die Materialien ab und speichern die Farben als Instanzen
    /// der Klasse Color ab.
    /// </summary>
    protected Color originalColor, highlightColor;

    /// <summary>
    /// Abfragen des Materials des GameObjects, dem
    /// diese Klasse hinzugefügt wurde und
    /// setzen der Farbe für das Hervorheben.
    /// </summary>
    protected void Start()
    {
        myMaterial = GetComponent<Renderer>().material;

        originalColor = myMaterial.color;
        highlightColor = highlightMaterial.color;
    }

    /// <summary>
    /// Callback, der in Awake() registriert 
    /// und in Update aufgerufen wird.
    /// 
    /// In dieser Funktion ist die Logik für das Wechseln der Farbe implementiert.
    /// Bemerkung: bei mehr als zwei Zuständen sollte man diese
    /// Funktionalität mit Hilfe einer finite state machine lösen!
    /// </summary>
    public override void Refresh()
    {
        if (!Mod.Status)
        {
            myMaterial.color = originalColor;
            if (logOutput)
                Debug.Log("Originalfarbe für " + gameObject.name);
        }
        else
        {
            myMaterial.color = highlightColor;
            if (logOutput)
                Debug.Log("Highlightfarbe für " + gameObject.name);
        }
    }
}
