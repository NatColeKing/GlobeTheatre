namespace VRTK.Examples
{
    using UnityEngine;

    public class Doors : MonoBehaviour
    {
      public VRTK_InteractableObject linkedObject;
      public GameObject door;
      public Vector3 ogAngle;
      public Vector3 newAngle;

      protected Transform spinner;
      protected bool spinning;

      protected virtual void OnEnable()
      {
          // door is closed
          // door.transform.rotation = Quaternion.Euler(ogAngle);
          spinning = false;
          linkedObject = (linkedObject == null ? GetComponent<VRTK_InteractableObject>() : linkedObject);

          if (linkedObject != null)
          {
              linkedObject.InteractableObjectUsed += InteractableObjectUsed;
              linkedObject.InteractableObjectUnused += InteractableObjectUnused;
          }

          spinner = transform.Find("Capsule");
      }

      protected virtual void OnDisable()
      {
          if (linkedObject != null)
          {
              linkedObject.InteractableObjectUsed -= InteractableObjectUsed;
              linkedObject.InteractableObjectUnused -= InteractableObjectUnused;
          }
      }

      protected virtual void Update()
      {
          if (spinning)
          {
              // open door
              door.transform.localRotation = Quaternion.Euler(newAngle);
          }
      }

      protected virtual void InteractableObjectUsed(object sender, InteractableObjectEventArgs e)
      {
          spinning = true;
      }

      protected virtual void InteractableObjectUnused(object sender, InteractableObjectEventArgs e)
      {
          // close door
          door.transform.localRotation = Quaternion.Euler(ogAngle);
          spinning = false;
      }
  }
}
