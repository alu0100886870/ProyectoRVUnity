using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/**
 * Controla la puerta que guarda la espada (se podría extender para otras puertas, pero para este nivel está bien con esto)
*/
public class UnlockableDoorController : SelectableObject {
    public bool locked = true;
	public string descriptionMessage = "La puerta parece estar cerrada por algún tipo de mecanismo.";

	// Use this for initialization
	void Start () {
        initProperties();
    }

    override
    public void onClick()
    {
		uiTextControl.setUIMessage(descriptionMessage);
       /* if (Vector3.Distance(character.position, transform.position) <= reticleProperties.getMaxDistance())
        {
            uiTextControl.setUIMessage("La puerta parece estar cerrada por algún tipo de mecanismo.");
        }*/
    }

    public void Unlock()
    {
        // Quitar la puerta al desbloquearla
		Destroy(gameObject);
            
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
