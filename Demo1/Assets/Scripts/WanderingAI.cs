using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    public float speed = 3.0f;
    public float obstacleRange = 5.0f;
    private bool _alive;
    [SerializeField] private GameObject projectilePrefab;
    private GameObject _projectile;

    // Start is called before the first frame update
    void Start()
    {
        _alive = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (_alive)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.SphereCast(ray, .75f, out hit))
            {
                GameObject hitobject = hit.transform.gameObject;
                if (hitobject.GetComponent<PlayerCharacter>())
                {
                    if(_projectile == null)
                    {
                        _projectile = Instantiate(projectilePrefab) as GameObject;
                        _projectile.transform.position = transform.TransformPoint(0,1,2);
                        _projectile.transform.rotation = transform.rotation;
                    }
                }
                else if (hit.distance < obstacleRange)
                {
                    float angle = Random.Range(-110, 110);
                    transform.Rotate(0, angle, 0);
                }
            }
        }
    }

    public void SetAlive(bool alive)
    {
        _alive = alive;
    }
}
