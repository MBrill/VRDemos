//========= 2020 - Copyright Manfred Brill. All rights reserved. ===========
using UnityEngine;

/// <summary>
/// Namespace für allgemeine Unity-Assets
/// </summary>
namespace VRKL.MBU
{
    /// <summary>
    /// Verwaltung von Weg-Punkten
    /// 
    /// Die Weg-Punkte werden periodisch angesteuert, das bedeutet,
    /// dass nach dem Erreichen des letzten Ziels wieder der erste
    /// Zielpunkt als neues Ziel verwendet wird.
    /// <remarks>
    /// Es ist geplant, dieses Verhalten zukünftig zu verändern
    /// und die Klasse entsprechend neu zu implementieren.
    /// </remarks>
    /// </summary>
    public class WaypointManager
    {
        /// <summary>
        /// Default-Konstruktor
        /// 
        /// Minimaler Abstand zum Zielobjekt 1.0,
        /// Keine Zielpunkte.
        /// </summary>
        public WaypointManager()
        {
            ArriveDistance = 1.0f;
            this.CurrentIndex = 0;
            this.TargetPositions = null;
        }

        /// <summary>
        /// Default-Konstruktor
        /// 
        /// Minimaler Abstand zum Zielobjekt 1.0,
        /// Keine Zielpunkte.
        /// </summary>
        /// <param name="distance">
        /// Abstand, ab dem ein Zielpunkt als erreicht eingestuft wird.
        /// </param>
        public WaypointManager(float distance)
        {
            ArriveDistance = distance;
            this.CurrentIndex = 0;
            this.TargetPositions = null;
        }

        /// <summary>
        /// Konstruktor mit Hilfe von GameObjects
        /// </summary>
        public WaypointManager(GameObject[] points)
        {
            var numberOfPoints = points.Length;
            CurrentIndex = 0;
            ArriveDistance = 1.0f;
            if (numberOfPoints > 1)
            {
                this.TargetPositions = new Vector3[numberOfPoints];
                for (int i = 0; i < numberOfPoints; i++)
                    this.TargetPositions[i] = points[i].transform.position;
            }
            else
                Debug.Log("Fehler im Konstruktor von WaypointManager -- keine Punkte übergeben");
        }

        /// <summary>
        /// Konstruktor mit Hilfe von GameObjects und Distanz
        /// </summary>
        /// <param name="points">Feld mit GameObjects, deren Position für
        /// die Zielpunkte verwendet wird
        /// </param>
        /// <param name="distance">Abstand, ab dem ein Zielpunkt als
        /// erreicht eingestuft wird.
        /// </param>
        public WaypointManager(GameObject[] points, float distance)
        {
            var numberOfPoints = points.Length;
            CurrentIndex = 0;
            ArriveDistance = distance;
            if (numberOfPoints > 1)
            {
                this.TargetPositions = new Vector3[numberOfPoints];
                for (int i = 0; i < numberOfPoints; i++)
                    this.TargetPositions[i] = points[i].transform.position;
            }
            else
                Debug.Log("Fehler im Konstruktor von WaypointManager -- keine Punkte übergeben");
        }

        /// <summary>
        /// Konstruktor mit Hilfe von Vector3-Instanzen
        /// </summary>
        /// <param name="points">
        /// Feld mit Vector3, die die Zielpunkte definieren.
        /// </param>
        public WaypointManager(Vector3[] points)
        {
            var numberOfPoints = points.Length;
            CurrentIndex = 0;
            ArriveDistance = 1.0f;
            if (numberOfPoints > 1)
            {
                this.TargetPositions = new Vector3[numberOfPoints];
                for (int i = 0; i < numberOfPoints; i++)
                    this.TargetPositions[i] = points[i];
            }
            else
                Debug.Log("Fehler im Konstruktor von WaypointManager -- keine Punkte übergeben");
        }

        /// <summary>
        /// Konstruktor mit Hilfe von Vector3-Instanzen
        /// </summary>
        /// <param name="points">
        /// Feld mit Vector3, die die Zielpunkte definieren.
        /// </param>
        /// <param name="distance">Abstand, ab dem ein Zielpunkt als
        /// erreicht eingestuft wird.
        /// </param>/// 
        public WaypointManager(Vector3[] points, float distance)
        {
            var numberOfPoints = points.Length;
            CurrentIndex = 0;
            ArriveDistance = distance;
            if (numberOfPoints > 1)
            {
                this.TargetPositions = new Vector3[numberOfPoints];
                for (int i = 0; i < numberOfPoints; i++)
                    this.TargetPositions[i] = points[i];
            }
            else
                Debug.Log("Fehler im Konstruktor von WaypointManager -- keine Punkte übergeben");
        }
        /// <summary>
        /// Minimaler Abstand zwischen einem Objekt und einem Zielpunkt.
        /// 
        /// Ist der Abstand zum aktuellen Zielpunkt kleiner als arriveDistance,
        /// dann verwenden wir den nächsten Zielpunkt.
        /// </summary>
        public float ArriveDistance { get; set; }

        /// <summary>
        /// Zurücksetzen der Waypoints, wir beginnen von vorne.
        /// </summary>
        public void ResetWaypoints()
        {
            CurrentIndex = 0;
        }

        /// <summary>
        /// Das nächste Ziel verwenden.
        /// </summary>
        public void NextWaypoint()
        {
            this.CurrentIndex++;
            // Wir verhalten uns periodisch und dividieren den Index
            // durch die Anzahl der Wegpunkte.
            this.CurrentIndex = this.CurrentIndex % this.TargetPositions.Length;
        }

        /// <summary>
        /// Abfragen des aktuellen Zielpunkts.
        /// </summary>
        /// <returns>
        /// Zielpunkt als Instanz von Vector3
        /// </returns>
        public Vector3 GetWaypoint()
        {
            return this.TargetPositions[this.CurrentIndex];
        }

        /// <summary>
        /// Setzen von Zielpunkten mit Hilfe von Punkten.
        /// Vorher vorhandene Zielpunkte werden überschrieben!
        /// </summary>
        /// <param name="points">
        /// Array mit Instanzen von Vector3 als Zielobjekte.
        /// </param>
        public void SetWaypoints(Vector3[] points)
        {
            var numberOfPoints = points.Length;
            if (numberOfPoints > 1)
            {
                this.TargetPositions = new Vector3[numberOfPoints];
                for (int i = 0; i < numberOfPoints; i++)
                    this.TargetPositions[i] = points[i];
            }
        }

        /// <summary>
        /// Setzen von Zielpunkten mit Hilfe von Punkten.
        /// Vorher vorhandene Zielpunkte werden überschrieben!
        /// </summary>
        /// <param name="points">
        /// Array mit Instanzen von GameObject als Zielobjekte.
        /// </param>
        public void SetWaypoints(GameObject[] points)
        {
            var numberOfPoints = points.Length;
            if (numberOfPoints > 1)
            {
                this.TargetPositions = new Vector3[numberOfPoints];
                for (int i = 0; i < numberOfPoints; i++)
                    this.TargetPositions[i] = points[i].transform.position;
            }
        }

        /// <summary>
        /// Berechnung einer Positionsveränderung in Richtung des aktuellen Zielpunkts.
        /// </summary>
        /// <remarks>
        /// Falls wir näher als arriveDistance an den aktuellen Zielpunkt kommen schaltet
        /// diese Funktion auf den nächsten Zielpunkt um!
        /// </remarks>
        /// <param name="distance">
        /// Wie groß soll der Schritt in Richtung des aktuellen Zielpunkts sein?
        /// </param>
        /// <param name="position">
        /// Die aktuelle Position, von der aus die Bewegung in Richtung des Zielpunkts erfolgen soll.
        /// </param>
        /// <returns>
        /// Neue Position, näher am Zielpunkt. Falls wir dabei einen Zielpunkt
        /// erreicht haben wir hier auch der  Zielpunkt gewechselt.
        /// </returns>
        public Vector3 Move(Vector3 position, float distance)
        {
            Vector3 newPosition;
            // Objekt mit Hilfe von MoveTowards bewegen
            newPosition = Vector3.MoveTowards(position, this.TargetPositions[this.CurrentIndex], distance);

            // Überprüfen, ob wir schon nah genug am Ziel sind und das
            // Ziel jetzt wechseln.
            if (Vector3.Distance(newPosition, this.TargetPositions[this.CurrentIndex]) < ArriveDistance)
                NextWaypoint();

            return newPosition;
        }

        /// <summary>
        /// Position der Zielpunkte
        /// </summary>
        private Vector3[] TargetPositions;
        /// <summary>
        /// Index des aktuellen und des nächsten Ziels
        /// 
        /// Wir beginnen beim ersten Eintrag des Ziels.
        /// </summary>
        private int CurrentIndex { get; set; }
    }
}
