using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PointerByRenderer : MonoBehaviour
{
    public Camera UIcamera;
    public GameObject point;
    public Canvas canvas;

    Vector3 pointPos;
    public GameObject[] Seagulls;
    public GameObject Player;

    public float refX = 0.98f;
    public float refY = 0.8f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        FindPoint();
        Seagulls = GameObject.FindGameObjectsWithTag("Seagull");

        //.Length


        if (point.GetComponent<Renderer>().isVisible && Seagulls.Length > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.clear;
        }
        else
        {


            gameObject.GetComponent<SpriteRenderer>().color = Color.white;

            Vector3[] canvasPoints = new Vector3[4];
            canvas.GetComponent<RectTransform>().GetLocalCorners(canvasPoints);

            Vector3 pointPos = WorldToScreenSpace(point.transform.position, UIcamera, canvas.GetComponent<RectTransform>());

            float xMin = canvasPoints[0].x * refX;
            float xMax = canvasPoints[2].x * refX;
            float yMin = canvasPoints[0].y * refY;
            float yMax = canvasPoints[2].y * refX;

            //POSITION
            if (pointPos.x <= xMin) pointPos.x = xMin;
            if (pointPos.x >= xMax) pointPos.x = xMax;
            if (pointPos.y <= yMin) pointPos.y = yMin;
            if (pointPos.y >= yMax) pointPos.y = yMax;

            pointPos.z = 0f;
            gameObject.transform.localPosition = pointPos;

            //ROTATION
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            Vector3 vectorToTarget = point.transform.position - gameObject.transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            angle -= 90;
            Quaternion newRotation = Quaternion.AngleAxis(angle, Vector3.forward);
            gameObject.transform.rotation = newRotation;

        }
    }

    public static Vector3 WorldToScreenSpace(Vector3 worldPos, Camera cam, RectTransform area)
    {
        Vector3 screenPoint = cam.WorldToScreenPoint(worldPos);
        screenPoint.z = 0;

        Vector2 screenPos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(area, screenPoint, cam, out screenPos))
        {
            return screenPos;
        }

        return screenPoint;
    }


    GameObject FindPoint()
    {
        float distance = Mathf.Infinity;
        foreach (GameObject go in Seagulls)
        {
            Vector2 diff = go.transform.position - Player.transform.position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                point = go;
                distance = curDistance;
            }
        }
        return point;
    }
}