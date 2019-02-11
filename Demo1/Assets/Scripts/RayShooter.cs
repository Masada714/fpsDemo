using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayShooter : MonoBehaviour
{
    private Camera _camera;
    public Text ammoCount;
    public int maxAmmo;
    public int currentAmmo;
    private AudioSource soundSource;
    public AudioClip hitEnemy;

    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        maxAmmo = 10;
        currentAmmo = maxAmmo;
        ammoCount.text = currentAmmo + "/" + maxAmmo;
        soundSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && currentAmmo > 0)
        {
            soundSource.PlayOneShot(hitEnemy);
            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
            Ray ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;
            currentAmmo--;
            ammoCount.text = currentAmmo + "/" + maxAmmo;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                if(target != null)
                {
                    target.ReactToHit();
                }
            }
            else
            {
                StartCoroutine(SphereIndicator(hit.point));
            }
        }
        if (Input.GetKey("r") && (currentAmmo < maxAmmo || currentAmmo == 0))
        {
            StartCoroutine(ReloadWeapon());
        }
    }

    private IEnumerator SphereIndicator(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;

        yield return new WaitForSeconds(1);
        Destroy(sphere);
    }

    private IEnumerator ReloadWeapon()
    {
        yield return new WaitForSeconds(2);
        currentAmmo = maxAmmo;
        ammoCount.text = currentAmmo + "/" + maxAmmo;
    }
}
