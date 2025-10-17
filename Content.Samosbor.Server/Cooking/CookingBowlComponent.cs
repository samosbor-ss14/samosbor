// using Content.Shared.Item;
// using Robust.Shared.Audio;
// using Robust.Shared.Containers;
// using Robust.Shared.Prototypes;
// using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom.Prototype;
//
// namespace Content.Samosbor.Server.Cooking
// {
//     [RegisterComponent]
//     public sealed partial class CookingBowlComponent : Component
//     {
//         [DataField(customTypeSerializer: typeof(PrototypeIdSerializer<EntityPrototype>))]
//         public string BadRecipeEntityId = "FoodBadRecipe";
//
//         [ViewVariables]
//         public bool Cooking = false;
//
//         [ViewVariables]
//         public TimeSpan StartTime;
//
//         [ViewVariables]
//         public string? CurrentRecipe;
//
//         [DataField, ViewVariables(VVAccess.ReadWrite)]
//         public float CookTime = 15f;
//
//         public Container Storage = default!;
//
//         [DataField]
//         public string ContainerId = "cooking_bowl_container";
//
//         [DataField, ViewVariables(VVAccess.ReadWrite)]
//         public int Capacity = 5;
//
//         #region Audio
//         [DataField]
//         public SoundSpecifier StartCookingSound = new SoundPathSpecifier("/Audio/Machines/microwave_start_beep.ogg");
//
//         [DataField]
//         public SoundSpecifier FoodDoneSound = new SoundPathSpecifier("/Audio/Machines/microwave_done_beep.ogg");
//         #endregion
//     }
// }
