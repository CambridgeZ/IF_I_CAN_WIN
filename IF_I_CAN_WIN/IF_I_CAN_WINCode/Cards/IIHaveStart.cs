using BaseLib.Utils;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models.CardPools;
using MegaCrit.Sts2.Core.Models.Powers;
using IF_I_CAN_WIN.IF_I_CAN_WINCode.Powers;

namespace IF_I_CAN_WIN.IF_I_CAN_WINCode.Cards;

[Pool(typeof(ColorlessCardPool))]
public sealed class IHaveStart : IF_I_CAN_WINCard
{
    public IHaveStart() : base(
        0, 
        CardType.Power, 
        CardRarity.Basic, 
        TargetType.Self)
    {
    }

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await PowerCmd.Apply<StrengthPower>(
            choiceContext,
            Owner.Creature,
            100,
            Owner.Creature,
            this,
            silent: false).ConfigureAwait(false);

        await PlayerCmd.GainEnergy(10, Owner).ConfigureAwait(false);
        await CardPileCmd.Draw(choiceContext, 10, Owner).ConfigureAwait(false);
        await PowerCmd.Apply<StrengthPower>(
            choiceContext,
            Owner.Creature,
            -100,
            Owner.Creature,
            this,
            silent: false).ConfigureAwait(false);

        await PowerCmd.Apply<IHaveStartPower>(
            choiceContext,
            Owner.Creature,
            1,
            Owner.Creature,
            this,
            silent: false).ConfigureAwait(false);
    }
}
