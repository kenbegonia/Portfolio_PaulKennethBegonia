using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class PlayerMoveControl : MonoBehaviour
{

    PlayerStateBehavior playerState;
    RaycastHit hit;
    Vector3 pointPosition;

	public AudioClip attack;
	public AudioClip damaged;
	public AudioClip pickup;
	private AudioSource source;
	public float vol = 3.5f;
	public Interactable m_focus;

    // Use this for initialization
    void Start()
    {
        playerState = GetComponent<PlayerStateBehavior>();
		source = GetComponent<AudioSource> ();
		StartCoroutine (Play ());
    }

    // Update is called once per frame
    void Update()
    {			
		if (EventSystem.current.IsPointerOverGameObject ())
			return;

        MouseControl();
    }

	IEnumerator Play()
	{
		while (true) 
		{
			if (playerState.currentState == playerState.attackState) 
			{
				PlaySound ();
			}

			yield return new WaitForSeconds (1.0f);
		}
	}

	void PlaySound()
	{
		source.PlayOneShot (attack, vol);
		source.PlayOneShot (damaged, vol);
	}

    void MouseControl()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log("Clicked");

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            pointPosition = hit.point;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                int layer = hit.transform.gameObject.layer;
                if (layer == LayerMask.NameToLayer("Field"))
                {
                    playerState.movePoint.position = pointPosition;
                    playerState.currentState = playerState.moveState;
                }
                if (layer == LayerMask.NameToLayer("Enemy"))
                {
                    if (playerState.attackPoint == null)
                    {
                        playerState.attackPoint = playerState.chooseTarget;
                    }
                    Debug.Log("Enemy Clicked");
                    playerState.attackPoint = hit.collider.GetComponent<Transform>();
                    Debug.Log(playerState.attackPoint);
                    playerState.currentState = playerState.chaseState;

                }
            }

			if (Physics.Raycast (ray, out hit, 100)) {
				Interactable interactable = hit.collider.GetComponent<Interactable> ();
				if (interactable != null) {
					SetFocus (interactable);
					source.PlayOneShot (pickup, vol);
				}
			}
        }
    }

	void SetFocus (Interactable newFocus) {
		if (newFocus != m_focus) {
			if(m_focus != null)
				m_focus.OnDefocused ();
			
			m_focus = newFocus;
			newFocus.OnFocused (transform);
		}
	}

	void RemoveFocus () {
		if(m_focus != null)
			m_focus.OnDefocused ();
		
		m_focus = null;
	}
}
