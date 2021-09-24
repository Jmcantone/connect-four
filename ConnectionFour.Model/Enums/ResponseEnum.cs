using System.ComponentModel;

namespace ConnectionFour.Model.Enums
{
    public enum ResponseEnum
    {
        [Description("A")]
        TeamAHasWon,
        [Description("B")]
        TeamBHasWon,
        [Description("X")]
        TheGameIsOngoing
    }
}
