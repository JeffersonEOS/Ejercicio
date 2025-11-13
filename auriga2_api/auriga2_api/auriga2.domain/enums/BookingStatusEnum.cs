using System.Runtime.Serialization;

namespace auriga2.domain.enums;

public enum BookingStatusEnum
{
    [EnumMember(Value = "NEW")]
    New,
    [EnumMember(Value = "ACCEPTED")]
    Accepted
}