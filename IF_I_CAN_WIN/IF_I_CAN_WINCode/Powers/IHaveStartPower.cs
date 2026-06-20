using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models.Powers;

namespace IF_I_CAN_WIN.IF_I_CAN_WINCode.Powers;

/// <summary>
/// Gives the owning player 100 Strength and 10 Energy at the start of each turn.
/// </summary>
public sealed class IHaveStartPower : IF_I_CAN_WINPower
{
    public override PowerType Type => PowerType.Buff;

    public override PowerStackType StackType => PowerStackType.Single;

    public override async Task AfterPlayerTurnStart(PlayerChoiceContext choiceContext, Player player)
    {
        await PowerCmd.Apply<StrengthPower>(
            choiceContext,
            player.Creature,
            100,
            player.Creature,
            cardSource: null,
            silent: false);

        await PlayerCmd.GainEnergy(10, player);
    }
}
