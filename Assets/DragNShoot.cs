using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://www.youtube.com/watch?v=Xu0urrCBSpw&t=45s thanks for Tyler Potts
public class DragNShoot : MonoBehaviour
{
    public float power = 10f;
    public Rigidbody2D rb;

    public Vector2 minPower;
    public Vector2 maxPower;

    Camera cam;
    Vector2 force;

    TrajectoryLine tl;

    Vector3 startPoint;
    Vector3 endPoint;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        tl = GetComponent<TrajectoryLine>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        if (Input.GetMouseButtonDown(0)) {
            startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            startPoint.z = 15f;
        }

        if (Input.GetMouseButton(0)) {
            Vector3 currentPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            currentPoint.z = 15f;
            
            tl.RenderLine(transform.position, new Vector3(pos.x + (pos.x - 2*currentPoint.x), pos.y + (pos.y - 2*currentPoint.y)));
        }

        if (Input.GetMouseButtonUp(0)) {
            endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            endPoint.z = 15f;

            force = new Vector2(Mathf.Clamp(pos.x - pos.x + (pos.x - 2*endPoint.x), minPower.x, maxPower.x), Mathf.Clamp(pos.y - pos.y + (pos.y - 2*endPoint.y), minPower.y, maxPower.y));
            rb.AddForce(force * power, ForceMode2D.Impulse);
            tl.EndLine();
        }
    }
}
