using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InRange : MonoBehaviour
{
    public int Segments = 32;
    public Color Color = Color.blue;
    public float XRadius = 1;
    public float YRadius = 1;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] racers =GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject racer in racers)
        {
            Vector2 player = racer.transform.position;
            Vector2 target = transform.position;
            float distance =  Mathf.Sqrt((target.x - player.x)*(target.x - player.x) + (target.y - player.y)*(target.y - player.y));
            
            if (distance<=2)
            {
                Color = Color.red;
            }

            else
            {
                Color = Color.blue;
            }

            Debug.Log(distance);
        }
    }

    private void OnDrawGizmos()
    {
        DrawEllipse(transform.position, transform.forward, transform.up, XRadius * transform.localScale.x, YRadius * transform.localScale.y, Segments, Color);
    }

    private static void DrawEllipse(Vector3 pos, Vector3 forward, Vector3 up, float radiusX, float radiusY, int segments, Color color, float duration = 0)
    {
        float angle = 0f;
        Quaternion rot = Quaternion.LookRotation(forward, up);
        Vector3 lastPoint = Vector3.zero;
        Vector3 thisPoint = Vector3.zero;

        for (int i = 0; i < segments + 1; i++)
        {
            thisPoint.x = Mathf.Sin(Mathf.Deg2Rad * angle) * radiusX;
            thisPoint.y = Mathf.Cos(Mathf.Deg2Rad * angle) * radiusY;

            if (i > 0)
            {
                Debug.DrawLine(rot * lastPoint + pos, rot * thisPoint + pos, color, duration);
            }

            lastPoint = thisPoint;
            angle += 360f / segments;
        }
    }
}
