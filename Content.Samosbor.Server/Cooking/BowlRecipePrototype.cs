// using Robust.Shared.Prototypes;
//
// namespace Content.Samosbor.Server.Cooking
// {
//     [Prototype("bowlRecipe")]
//     public sealed partial class BowlRecipePrototype : IPrototype
//     {
//         [ViewVariables]
//         [IdDataField]
//         public string ID { get; private set; } = default!;
//
//         [DataField(required: true)]
//         public string ProductEntity { get; private set; } = string.Empty;
//
//         [DataField(required: true)]
//         public float Time { get; private set; } = 120f;
//
//         [DataField(required: true)]
//         public Dictionary<string, int> Solids { get; private set; } = new();
//     }
// }
