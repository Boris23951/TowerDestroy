using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class MiddleInput : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	private bool pointerDown;
	private float pointerDownTimer;

	[SerializeField]
	private float requiredHoldTime;//возвращает false/true через f задержки(таймер)

	public UnityEvent onLongClick;

	public void OnPointerDown(PointerEventData eventData)
	{
		pointerDown = true;
		Player.shootOnTouch = true;
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		Reset();
		Player.shootOnTouch = false;
	}

	private void Update()
	{
		if (pointerDown)
		{
			pointerDownTimer += Time.deltaTime;
			if (pointerDownTimer >= requiredHoldTime)
			{
				if (onLongClick != null)
					onLongClick.Invoke();

				Reset();
			}
		}
	}

	public void Reset()
	{
		pointerDown = false;
		pointerDownTimer = 0;
	}
}
