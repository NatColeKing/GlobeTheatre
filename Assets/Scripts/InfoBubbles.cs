namespace VRTK.Examples
{
    using UnityEngine;

    public class InfoBubbles : MonoBehaviour
    {
      public VRTK_InteractableObject linkedObject;
      public GameObject title;
      public GameObject parchment;
      public GameObject description;

      protected Transform obj;
      protected bool on;

      protected virtual void OnEnable()
      {
          // player = GameObject.Find("Player").transform;
          description.SetActive(false);
          title.SetActive(false);
          parchment.SetActive(false);
          on = false;
          linkedObject = (linkedObject == null ? GetComponent<VRTK_InteractableObject>() : linkedObject);

          if (linkedObject != null)
          {
              linkedObject.InteractableObjectUsed += InteractableObjectUsed;
              linkedObject.InteractableObjectUnused += InteractableObjectUnused;
          }

          obj = transform.Find("Capsule");
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
          // transform.LookAt(player);
          if (on)
          {
              description.SetActive(true);
              title.SetActive(true);
              parchment.SetActive(true);
          }
      }

      protected virtual void InteractableObjectUsed(object sender, InteractableObjectEventArgs e)
      {
          on = true;
      }

      protected virtual void InteractableObjectUnused(object sender, InteractableObjectEventArgs e)
      {
          description.SetActive(false);
          title.SetActive(false);
          parchment.SetActive(false);
          on = false;
      }
  }
}
