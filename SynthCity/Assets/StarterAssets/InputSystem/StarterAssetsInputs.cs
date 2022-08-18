using UnityEngine;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public Vector2 scroll;
		public bool jump;
		public bool sprint;
		public bool interact;
		public bool moduleKey;
		public bool click;

		[Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;

#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED

        public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			if(cursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
			}
		}

		public void OnJump(InputValue value)
		{
			JumpInput(value.isPressed);
		}

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}

		public void OnScroll(InputValue value)
        {
			ScrollInput(value.Get<Vector2>());
        }

		public void OnPause(InputValue value)
        {
			cursorLocked = !cursorLocked;
			SetCursorState(cursorLocked);
			cursorInputForLook = !cursorInputForLook;   
        }

		public void OnInteract(InputValue value)
        {
			InteractInput(value.isPressed);
        }

		public void OnModuleKey(InputValue value)
        {
			ModuleInput(value.isPressed);
        }
		
		public void OnMouseToggle()
        {
			cursorLocked = !cursorLocked;
			SetCursorState(cursorLocked);
			cursorInputForLook = !cursorInputForLook;
			LookInput(new Vector2 (0, 0));
		}

		public void OnClick(InputValue value)
        {
			ClickInput(value.isPressed);
        }

#endif
		public void ScrollInput(Vector2 newScroll)
        {
			scroll = newScroll;
        }
		public void ClickInput(bool newClick)
        {
			click = newClick;
        }
		public void InteractInput(bool newInteraction)
        {
			interact = newInteraction;
        }

		public void ModuleInput(bool newInput)
		{
			moduleKey = newInput;
		}

		public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}

		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}
		
		private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}
	}
	
}