using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private int rayLayerMask;
    private Camera fpsCam;
    public float reachRange = 1.8f;
    bool nighStandClosed = true;
    bool topdrawerClosed = true;
    bool bottomdrawerClosed = true;
    bool leftdoorwardobeClosed = true;
    bool rightdoorwardobeClosed = true;
    // Start is called before the first frame update
    void Start()
    {
        fpsCam = Camera.main;
        LayerMask iRayLM = LayerMask.NameToLayer("Item");
        rayLayerMask = 1 << iRayLM.value;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        //if raycast hits a collider on the rayLayerMask
        if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, reachRange, rayLayerMask))
        {





            if (Input.GetKeyUp(KeyCode.E) || Input.GetButtonDown("Fire1"))
            {
                print(hit.collider.gameObject.name);
                if (hit.collider.gameObject.tag.ToLower() == "door")
                {
                    hit.collider.gameObject.transform.parent.transform.DORotate(new Vector3(90, 0, -90), 3);
                }
                if (hit.collider.gameObject.tag.ToLower() == "nightstand")
                {
                    if (nighStandClosed)
                    {
                        hit.collider.gameObject.GetComponentInParent<Animator>().Play("Open");
                        nighStandClosed = false;
                    }
                    else
                    {
                        hit.collider.gameObject.GetComponentInParent<Animator>().Play("Close");
                        nighStandClosed = true;
                    }
                }
                TopDrawerAnimation(hit);
                BottomDrawerAnimation(hit);
                OpenLeftDoorWardobe(hit);
                OpenRightDoorWardobe(hit);
                ButtonClick(hit);
            }


        }

    }

    private void TopDrawerAnimation(RaycastHit hit)
    {
        if (hit.collider.gameObject.tag.ToLower() == "topdrawer")
        {
            if (topdrawerClosed)
            {
                hit.collider.gameObject.GetComponentInParent<Animator>().Play("OpenT");
                topdrawerClosed = false;
            }
            else
            {
                hit.collider.gameObject.GetComponentInParent<Animator>().Play("CloseT");
                topdrawerClosed = true;
            }
        }
    }
    private void BottomDrawerAnimation(RaycastHit hit)
    {
        if (hit.collider.gameObject.tag.ToLower() == "bottomdrawer")
        {
            if (bottomdrawerClosed)
            {
                hit.collider.gameObject.GetComponentInParent<Animator>().Play("OpenB");
                bottomdrawerClosed = false;
            }
            else
            {
                hit.collider.gameObject.GetComponentInParent<Animator>().Play("CloseB");
                bottomdrawerClosed = true;
            }
        }
    }
    private void OpenLeftDoorWardobe(RaycastHit hit)
    {
        if (hit.collider.gameObject.tag.ToLower() == "leftdoorwardobe")
        {
            if (leftdoorwardobeClosed)
            {
                hit.collider.gameObject.GetComponentInParent<Animator>().Play("OpenL");
                leftdoorwardobeClosed = false;
            }
            else
            {
                hit.collider.gameObject.GetComponentInParent<Animator>().Play("CloseL");
                leftdoorwardobeClosed = true;
            }
        }
    }
    private void OpenRightDoorWardobe(RaycastHit hit)
    {
        if (hit.collider.gameObject.tag.ToLower() == "rightdoorwardobe")
        {
            if (rightdoorwardobeClosed)
            {
                hit.collider.gameObject.GetComponentInParent<Animator>().Play("OpenR");
                rightdoorwardobeClosed = false;
            }
            else
            {
                hit.collider.gameObject.GetComponentInParent<Animator>().Play("CloseR");
                rightdoorwardobeClosed = true;
            }
        }
    }

    private void ButtonClick(RaycastHit hit)
    {
        if (hit.collider.gameObject.tag.ToLower() == "restartbutton")
        {
            SceneManager.LoadScene("VirtualWalkthrough");
        }
        if (hit.collider.gameObject.tag.ToLower() == "backbutton")
        {
           
            SceneManager.LoadScene("MainMenu");
        }

    }
}
