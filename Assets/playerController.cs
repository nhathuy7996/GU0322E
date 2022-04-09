using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [SerializeField] Queue<Vector3> targets = new Queue<Vector3>();
    [SerializeField] float Speed = 100;

    Vector3 currentTarget = Vector3.zero;

    int currentIndex = 0;

    private void Awake()
    {
       
       
    }

    // Start is called before the first frame update
    void Start()
    {
        //this.transform.position = new Vector3(10,10,0);

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(targets.Count);

        if (Input.GetMouseButtonDown(0))
        {
            //reset taget
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            worldPos.z = 0;

            targets.Enqueue(worldPos);
        }

        if (targets.Count == 0)
            return;

        if (currentIndex >= targets.Count)
            return;


        this.transform.position = Vector3.MoveTowards(this.transform.position, currentTarget, Speed * Time.deltaTime);


        if (currentTarget == Vector3.zero || Vector2.Distance(this.transform.position, currentTarget) <= 0.5f)
            currentTarget = targets.Dequeue();

        //Time.timeScale = 0;


        //if (Input.GetMouseButton(0))
        //{
        //    Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //    worldPos.z = 0;

        //    this.transform.position = worldPos;
        //}

    }


    private void FixedUpdate()
    {
        
    }
}


