/*
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
 *
 * @Filename :		TouchToParent.cs
 * @Copyright :		SARL Dreamtronic 2012 - 52265807900028
 * @Author :		Nicolas Lolm�de
 * @Version :		1.0
 * @Description :	Renvoi les �v�nements GestureWorks au GameObject parent.
 *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
 *
 * Ce script peut �tre pr�sent plusieurs fois dans la sc�ne, �mais une seule fois par gameObject.
 * 
 * Param�tres disponibles :
 * - X
 *
 */

using UnityEngine;
using System.Collections;
using GestureWorksCoreNET;
using GestureWorksCoreNET.Unity;
using Swifty;

public class TouchToParent : TouchObject
{

    // ### PROPERTIES ####################################################################

    // Accessibles dans l'inspecteur
    /* Propri�t�s publiques, visibles dans l'inspecteur */

    // Accessibles dans d'autres scripts
    /* Propri�t�s publiques, mais avec {get/set}, et donc non visibles en inspecteur */

    // Priv�es
    /* Propri�t�s strictement priv�es */
    private GameObject papou;


    // ### INITIALISATION ################################################################
    void Awake()
    {
        papou = this.transform.parent.gameObject;
        if (!papou)
        {
            Debug.Log("[TouchToParent] Pas de parent !");
            Destroy(this);
        }
    }


    // ### 1ST FRAME #####################################################################
    //void Start() {}


    // ### UPDATE ########################################################################
    //void Update() {}


    // ### MULTITOUCH ####################################################################

    public void set_pEvent(int pointID)
    {
        papou.SendMessage("set_pEvent", pointID, SendMessageOptions.DontRequireReceiver);
    }

    public void NDrag(GestureEvent gEvent)
    {
        papou.SendMessage("NDrag", gEvent, SendMessageOptions.DontRequireReceiver);
    }

    public void Drag(GestureEvent gEvent)
    {
        papou.SendMessage("Drag", gEvent, SendMessageOptions.DontRequireReceiver);
    }

    // Rotate � un seul doigt
    public void Rotate(GestureEvent gEvent)
    {
        papou.SendMessage("Rotate", gEvent, SendMessageOptions.DontRequireReceiver);
    }

    // Rotate � plusieurs doigts
    public void NRotate(GestureEvent gEvent)
    {
        papou.SendMessage("NRotate", gEvent, SendMessageOptions.DontRequireReceiver);
    }

    // Scale � un seul doigt
    public void Scale(GestureEvent gEvent)
    {
        papou.SendMessage("Scale", gEvent, SendMessageOptions.DontRequireReceiver);
    }

    // Scale � plusieurs doigts
    public void NScale(GestureEvent gEvent)
    {
        papou.SendMessage("NScale", gEvent, SendMessageOptions.DontRequireReceiver);
    }
    // ### TOOLS #########################################################################

}