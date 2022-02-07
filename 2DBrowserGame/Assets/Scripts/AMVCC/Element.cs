using UnityEngine;

public class Element : MonoBehaviour{
    public Application app { get { return GameObject.FindObjectOfType<Application>(); } }
}
