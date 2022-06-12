using System.ComponentModel;

namespace BasicsForExperts.Web.DTOs
{
    public enum WaffleTypeEnum
    {
        Default = 0,

        [Description("LowFat")]
        LowFat = 1,

        [Description("Savoury")]
        Savoury = 2,
        
        [Description("Standard")]
        Standard = 3
    }
}
