using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    [SerializeField] private float velocityMovement;
    [SerializeField] private float distancia;
    [SerializeField] private LayerMask layerMask;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement(){
        rigidbody2D.velocity = new Vector2(velocityMovement * transform.right.x, rigidbody2D.velocity.y);
        RaycastHit2D informationWall = Physics2D.Raycast(transform.position, transform.right, distancia, layerMask);

        if (informationWall){
            Girar();
        }
    }

    private void Girar(){
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y +180, 0);
    }

    private void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.right * distancia);
    }
}
