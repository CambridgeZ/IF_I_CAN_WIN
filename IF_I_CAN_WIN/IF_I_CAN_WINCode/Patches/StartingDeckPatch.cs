using HarmonyLib;
using IF_I_CAN_WIN.IF_I_CAN_WINCode.Cards;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Models;

namespace IF_I_CAN_WIN.IF_I_CAN_WINCode.Patches;

/// <summary>
/// Adds one innate IHaveStart card to every character's deck when a new run is created.
/// </summary>
[HarmonyPatch(typeof(Player), "PopulateStartingDeck")]
internal static class StartingDeckPatch
{
    [HarmonyPostfix]
    private static void AddIHaveStart(Player __instance)
    {
        if (__instance.Deck.Cards.Any(card => card is IHaveStart))
            return;

        CardModel card = ModelDb.Card<IHaveStart>().ToMutable();
        card.FloorAddedToDeck = 1;
        __instance.Deck.AddInternal(card);
    }
}
