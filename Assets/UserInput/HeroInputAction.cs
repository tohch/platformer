// GENERATED AUTOMATICALLY FROM 'Assets/UserInput/HeroInputAction.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @HeroInputAction : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @HeroInputAction()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""HeroInputAction"",
    ""maps"": [
        {
            ""name"": ""Hero"",
            ""id"": ""56a5b638-1f4d-4fd0-bc73-da18c0260ef3"",
            ""actions"": [
                {
                    ""name"": ""HorizontalMovement"",
                    ""type"": ""Value"",
                    ""id"": ""71b55e6e-4744-4855-a6da-e8882d12e020"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SaySomething"",
                    ""type"": ""Button"",
                    ""id"": ""0dcf3974-6219-4001-974b-d3fb031687be"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""a8773a90-b839-44d9-84e6-cf55956b1ed6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""2be5902c-2c82-44ca-9b84-8d51797aa079"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Throw"",
                    ""type"": ""Button"",
                    ""id"": ""50a246bf-cda5-4571-809f-0bc69cbefb64"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UseHealPotion"",
                    ""type"": ""Button"",
                    ""id"": ""f4ef360a-4a57-4102-b215-43c4a738697e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""OnDrop"",
                    ""type"": ""Button"",
                    ""id"": ""0090f4c2-5458-4d58-8594-afe6eead0147"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""NextItem"",
                    ""type"": ""Button"",
                    ""id"": ""18d0a94a-34a0-438a-9711-e805c81ad809"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UsePerk"",
                    ""type"": ""Button"",
                    ""id"": ""0feeaa53-4d04-476f-b8c8-b0f86cdeaf34"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UseFlashLight"",
                    ""type"": ""Button"",
                    ""id"": ""863d7309-2293-460c-870b-c6c0a5e9aa00"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""ca73fc18-a073-4cf5-a04f-51547de42dea"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Up"",
                    ""id"": ""9836f00d-0b39-497d-97d9-6a246918db2c"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Down"",
                    ""id"": ""38d8248c-fd1d-40b0-b1ab-d4cdd1dac690"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Left"",
                    ""id"": ""920effaf-2ea2-40b0-bc45-5f281a8ff453"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Right"",
                    ""id"": ""4b963ff3-39b3-4fef-846a-508ddd5bf926"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""84cf05a6-399c-439f-90e4-a419388bcb02"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Up"",
                    ""id"": ""c9b4f5fa-1da0-47d5-ad17-b9ae777000da"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Down"",
                    ""id"": ""52aab9c7-4e4a-4387-ad45-dd14fb716bf1"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Left"",
                    ""id"": ""e382884e-b0ed-47f1-9c5f-65a783ecd1a5"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Right"",
                    ""id"": ""c305be27-c48c-4529-ba2d-0b4b9ec596af"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""1cd9dcab-1aec-44b0-816c-b79e9c00baf6"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone(min=0.4)"",
                    ""groups"": """",
                    ""action"": ""HorizontalMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""08fcea5a-de33-4c07-ba6e-4b29b2ae122f"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SaySomething"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fcb6796a-d385-4a1b-8483-a749ad24fc64"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""301a5f50-1ffa-4294-aea8-77818c79c895"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0a4a6e4b-003e-42a2-9f50-e19fab3d1414"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""902dd701-0bbd-4385-825b-7f5f6326b311"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b8e62919-4da9-417e-98a6-60ef10ece55c"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3b3a1a65-cf19-42a8-b768-d8a9098a25c2"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a40d0514-16e0-43f3-b357-53be1ba5babd"",
                    ""path"": ""<Keyboard>/h"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UseHealPotion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""drop"",
                    ""id"": ""fcbec267-c20e-4eea-8fc8-02e5cf3ac28a"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnDrop"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""8b3791dd-7c17-4045-b75e-d8ba9242a5b3"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnDrop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""b43e1ff4-e029-4b7b-ab9a-5f338e7d87c4"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnDrop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""987fe8e2-e99b-4213-ba02-9869c2ee6d14"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NextItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a040df57-4b6c-4b96-9b92-2e2f4dc11f60"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NextItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""572d331d-f52c-48bb-80db-519c6c49ee65"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UsePerk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a5ec7747-637d-4b4a-885e-69fc3309d4c6"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UseFlashLight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Hero
        m_Hero = asset.FindActionMap("Hero", throwIfNotFound: true);
        m_Hero_HorizontalMovement = m_Hero.FindAction("HorizontalMovement", throwIfNotFound: true);
        m_Hero_SaySomething = m_Hero.FindAction("SaySomething", throwIfNotFound: true);
        m_Hero_Interact = m_Hero.FindAction("Interact", throwIfNotFound: true);
        m_Hero_Attack = m_Hero.FindAction("Attack", throwIfNotFound: true);
        m_Hero_Throw = m_Hero.FindAction("Throw", throwIfNotFound: true);
        m_Hero_UseHealPotion = m_Hero.FindAction("UseHealPotion", throwIfNotFound: true);
        m_Hero_OnDrop = m_Hero.FindAction("OnDrop", throwIfNotFound: true);
        m_Hero_NextItem = m_Hero.FindAction("NextItem", throwIfNotFound: true);
        m_Hero_UsePerk = m_Hero.FindAction("UsePerk", throwIfNotFound: true);
        m_Hero_UseFlashLight = m_Hero.FindAction("UseFlashLight", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Hero
    private readonly InputActionMap m_Hero;
    private IHeroActions m_HeroActionsCallbackInterface;
    private readonly InputAction m_Hero_HorizontalMovement;
    private readonly InputAction m_Hero_SaySomething;
    private readonly InputAction m_Hero_Interact;
    private readonly InputAction m_Hero_Attack;
    private readonly InputAction m_Hero_Throw;
    private readonly InputAction m_Hero_UseHealPotion;
    private readonly InputAction m_Hero_OnDrop;
    private readonly InputAction m_Hero_NextItem;
    private readonly InputAction m_Hero_UsePerk;
    private readonly InputAction m_Hero_UseFlashLight;
    public struct HeroActions
    {
        private @HeroInputAction m_Wrapper;
        public HeroActions(@HeroInputAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @HorizontalMovement => m_Wrapper.m_Hero_HorizontalMovement;
        public InputAction @SaySomething => m_Wrapper.m_Hero_SaySomething;
        public InputAction @Interact => m_Wrapper.m_Hero_Interact;
        public InputAction @Attack => m_Wrapper.m_Hero_Attack;
        public InputAction @Throw => m_Wrapper.m_Hero_Throw;
        public InputAction @UseHealPotion => m_Wrapper.m_Hero_UseHealPotion;
        public InputAction @OnDrop => m_Wrapper.m_Hero_OnDrop;
        public InputAction @NextItem => m_Wrapper.m_Hero_NextItem;
        public InputAction @UsePerk => m_Wrapper.m_Hero_UsePerk;
        public InputAction @UseFlashLight => m_Wrapper.m_Hero_UseFlashLight;
        public InputActionMap Get() { return m_Wrapper.m_Hero; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(HeroActions set) { return set.Get(); }
        public void SetCallbacks(IHeroActions instance)
        {
            if (m_Wrapper.m_HeroActionsCallbackInterface != null)
            {
                @HorizontalMovement.started -= m_Wrapper.m_HeroActionsCallbackInterface.OnHorizontalMovement;
                @HorizontalMovement.performed -= m_Wrapper.m_HeroActionsCallbackInterface.OnHorizontalMovement;
                @HorizontalMovement.canceled -= m_Wrapper.m_HeroActionsCallbackInterface.OnHorizontalMovement;
                @SaySomething.started -= m_Wrapper.m_HeroActionsCallbackInterface.OnSaySomething;
                @SaySomething.performed -= m_Wrapper.m_HeroActionsCallbackInterface.OnSaySomething;
                @SaySomething.canceled -= m_Wrapper.m_HeroActionsCallbackInterface.OnSaySomething;
                @Interact.started -= m_Wrapper.m_HeroActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_HeroActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_HeroActionsCallbackInterface.OnInteract;
                @Attack.started -= m_Wrapper.m_HeroActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_HeroActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_HeroActionsCallbackInterface.OnAttack;
                @Throw.started -= m_Wrapper.m_HeroActionsCallbackInterface.OnThrow;
                @Throw.performed -= m_Wrapper.m_HeroActionsCallbackInterface.OnThrow;
                @Throw.canceled -= m_Wrapper.m_HeroActionsCallbackInterface.OnThrow;
                @UseHealPotion.started -= m_Wrapper.m_HeroActionsCallbackInterface.OnUseHealPotion;
                @UseHealPotion.performed -= m_Wrapper.m_HeroActionsCallbackInterface.OnUseHealPotion;
                @UseHealPotion.canceled -= m_Wrapper.m_HeroActionsCallbackInterface.OnUseHealPotion;
                @OnDrop.started -= m_Wrapper.m_HeroActionsCallbackInterface.OnOnDrop;
                @OnDrop.performed -= m_Wrapper.m_HeroActionsCallbackInterface.OnOnDrop;
                @OnDrop.canceled -= m_Wrapper.m_HeroActionsCallbackInterface.OnOnDrop;
                @NextItem.started -= m_Wrapper.m_HeroActionsCallbackInterface.OnNextItem;
                @NextItem.performed -= m_Wrapper.m_HeroActionsCallbackInterface.OnNextItem;
                @NextItem.canceled -= m_Wrapper.m_HeroActionsCallbackInterface.OnNextItem;
                @UsePerk.started -= m_Wrapper.m_HeroActionsCallbackInterface.OnUsePerk;
                @UsePerk.performed -= m_Wrapper.m_HeroActionsCallbackInterface.OnUsePerk;
                @UsePerk.canceled -= m_Wrapper.m_HeroActionsCallbackInterface.OnUsePerk;
                @UseFlashLight.started -= m_Wrapper.m_HeroActionsCallbackInterface.OnUseFlashLight;
                @UseFlashLight.performed -= m_Wrapper.m_HeroActionsCallbackInterface.OnUseFlashLight;
                @UseFlashLight.canceled -= m_Wrapper.m_HeroActionsCallbackInterface.OnUseFlashLight;
            }
            m_Wrapper.m_HeroActionsCallbackInterface = instance;
            if (instance != null)
            {
                @HorizontalMovement.started += instance.OnHorizontalMovement;
                @HorizontalMovement.performed += instance.OnHorizontalMovement;
                @HorizontalMovement.canceled += instance.OnHorizontalMovement;
                @SaySomething.started += instance.OnSaySomething;
                @SaySomething.performed += instance.OnSaySomething;
                @SaySomething.canceled += instance.OnSaySomething;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Throw.started += instance.OnThrow;
                @Throw.performed += instance.OnThrow;
                @Throw.canceled += instance.OnThrow;
                @UseHealPotion.started += instance.OnUseHealPotion;
                @UseHealPotion.performed += instance.OnUseHealPotion;
                @UseHealPotion.canceled += instance.OnUseHealPotion;
                @OnDrop.started += instance.OnOnDrop;
                @OnDrop.performed += instance.OnOnDrop;
                @OnDrop.canceled += instance.OnOnDrop;
                @NextItem.started += instance.OnNextItem;
                @NextItem.performed += instance.OnNextItem;
                @NextItem.canceled += instance.OnNextItem;
                @UsePerk.started += instance.OnUsePerk;
                @UsePerk.performed += instance.OnUsePerk;
                @UsePerk.canceled += instance.OnUsePerk;
                @UseFlashLight.started += instance.OnUseFlashLight;
                @UseFlashLight.performed += instance.OnUseFlashLight;
                @UseFlashLight.canceled += instance.OnUseFlashLight;
            }
        }
    }
    public HeroActions @Hero => new HeroActions(this);
    public interface IHeroActions
    {
        void OnHorizontalMovement(InputAction.CallbackContext context);
        void OnSaySomething(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnThrow(InputAction.CallbackContext context);
        void OnUseHealPotion(InputAction.CallbackContext context);
        void OnOnDrop(InputAction.CallbackContext context);
        void OnNextItem(InputAction.CallbackContext context);
        void OnUsePerk(InputAction.CallbackContext context);
        void OnUseFlashLight(InputAction.CallbackContext context);
    }
}
