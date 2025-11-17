using System.ComponentModel.DataAnnotations;

namespace auriga2.domain.enums
{
    public enum EnumTipoCuenta
    {
        [System.ComponentModel.Description("Corriente")]
        Corriente=2,

        [System.ComponentModel.Description("Ahorro")]
        Ahorro=1
    }
}
