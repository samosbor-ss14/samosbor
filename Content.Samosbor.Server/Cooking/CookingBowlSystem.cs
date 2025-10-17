// using Content.Server.Kitchen.Components;
// using Robust.Shared.Containers;
// using Robust.Shared.Prototypes;
// using Robust.Shared.Timing;
//
// // this was based on microwavesystem
// namespace Content.Samosbor.Server.Cooking
// {
//     public sealed partial class BowlSystem : EntitySystem
//     {
//         [Dependency] private readonly IPrototypeManager _prototypeManager = default!;
//         [Dependency] private readonly IGameTiming _gameTiming = default!;
//         [Dependency] private readonly SharedContainerSystem _container = default!;
//
//         public override void Initialize()
//         {
//             base.Initialize();
//
//             SubscribeLocalEvent<CookingBowlComponent, ComponentInit>(OnComponentInit);
//             SubscribeLocalEvent<CookingBowlComponent, ContainerIsInsertingAttemptEvent>(OnInsertAttempt);
//             SubscribeLocalEvent<CookingBowlComponent, EntInsertedIntoContainerMessage>(OnEntInserted);
//         }
//
//         private void OnComponentInit(EntityUid uid, CookingBowlComponent component, ComponentInit args)
//         {
//             component.Storage = _container.EnsureContainer<Container>(uid, component.ContainerId);
//         }
//
//         private void OnInsertAttempt(EntityUid uid, CookingBowlComponent component, ContainerIsInsertingAttemptEvent args)
//         {
//             if (component.Cooking)
//             {
//                 args.Cancel();
//                 return;
//             }
//
//             if (component.Storage.ContainedEntities.Count >= component.Capacity)
//             {
//                 args.Cancel();
//                 return;
//             }
//         }
//
//         private void OnEntInserted(EntityUid uid, CookingBowlComponent component, EntInsertedIntoContainerMessage args)
//         {
//             if (args.Container.ID != component.ContainerId)
//                 return;
//
//             if (component.Storage.ContainedEntities.Count == 1 && !component.Cooking)
//                 StartCooking(uid, component);
//         }
//
//         private void StartCooking(EntityUid uid, CookingBowlComponent component)
//         {
//             component.Cooking = true;
//             component.StartTime = _gameTiming.CurTime;
//
//             uid.SpawnTimer(TimeSpan.FromSeconds(component.CookTime), () => CheckRecipe(uid, component));
//         }
//
//         private void CheckRecipe(EntityUid uid, CookingBowlComponent component)
//         {
//             if (!component.Cooking
//                 || Deleted(uid))
//                 return;
//
//             var ingredientTypes = new Dictionary<string, int>();
//
//             foreach (var ingredient in component.Storage.ContainedEntities)
//             {
//                 if (MetaData(ingredient).EntityPrototype is { } prototype)
//                 {
//                     var id = prototype.ID;
//                     ingredientTypes[id] = ingredientTypes.GetValueOrDefault(id) + 1;
//                 }
//             }
//
//             var recipes = _prototypeManager.EnumeratePrototypes<BowlRecipePrototype>();
//             BowlRecipePrototype? matchedRecipe = null;
//
//             foreach (var recipe in recipes)
//             {
//                 if (CheckRecipeMatch(recipe, ingredientTypes))
//                 {
//                     matchedRecipe = recipe;
//                     break;
//                 }
//             }
//
//             if (matchedRecipe != null)
//             {
//                 CompleteCooking(uid, component, matchedRecipe);
//             }
//             else
//             {
//                 SpawnBadRecipe(uid, component);
//             }
//         }
//
//         private bool CheckRecipeMatch(BowlRecipePrototype recipe, Dictionary<string, int> ingredientTypes)
//         {
//             foreach (var (requiredId, requiredCount) in recipe.Solids)
//             {
//                 if (!ingredientTypes.TryGetValue(requiredId, out var actualCount)
//                     || actualCount < requiredCount)
//                     return false;
//             }
//             return true;
//         }
//
//         private void CompleteCooking(EntityUid uid, CookingBowlComponent component, BowlRecipePrototype recipe)
//         {
//             _container.EmptyContainer(component.Storage);
//
//             var transform = Transform(uid);
//             Spawn(recipe.ProductEntity, transform.Coordinates);
//
//             ResetCooking(uid, component);
//         }
//
//         private void SpawnBadRecipe(EntityUid uid, CookingBowlComponent component)
//         {
//             _container.EmptyContainer(component.Storage);
//
//             var transform = Transform(uid);
//             Spawn(component.BadRecipeEntityId, transform.Coordinates);
//
//             ResetCooking(uid, component);
//         }
//
//         private void ResetCooking(EntityUid uid, CookingBowlComponent component)
//         {
//             component.Cooking = false;
//             component.StartTime = TimeSpan.Zero;
//             component.CurrentRecipe = null;
//         }
//     }
// }
