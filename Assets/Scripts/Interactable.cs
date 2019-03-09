namespace VRTK.Examples
{
    using UnityEngine;

    public class Interactable : MonoBehaviour
    {
      public VRTK_InteractableObject linkedObject;
      public GameObject blurb;

      protected Transform spinner;
      protected bool spinning;

      protected virtual void OnEnable()
      {
          blurb.SetActive(false);
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
              blurb.SetActive(true);
          }
      }

      protected virtual void InteractableObjectUsed(object sender, InteractableObjectEventArgs e)
      {
          spinning = true;
      }

      protected virtual void InteractableObjectUnused(object sender, InteractableObjectEventArgs e)
      {
          blurb.SetActive(false);
          spinning = false;
      }
  }
}
