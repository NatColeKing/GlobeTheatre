namespace VRTK.Examples
{
    using UnityEngine;

    public class InfoBubbles : MonoBehaviour
    {
      public VRTK_InteractableObject linkedObject;
      public GameObject title;
      public GameObject description;

      protected Transform spinner;
      protected bool spinning;

      protected virtual void OnEnable()
      {
          description.SetActive(false);
          title.SetActive(false);
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
              description.SetActive(true);
              title.SetActive(true);
          }
      }

      protected virtual void InteractableObjectUsed(object sender, InteractableObjectEventArgs e)
      {
          spinning = true;
      }

      protected virtual void InteractableObjectUnused(object sender, InteractableObjectEventArgs e)
      {
          description.SetActive(false);
          title.SetActive(false);
          spinning = false;
      }
  }
}
