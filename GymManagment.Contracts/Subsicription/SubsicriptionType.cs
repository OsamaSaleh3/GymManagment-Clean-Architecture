using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
namespace GymManagment.Contracts.Subsicription;

[JsonConverter(typeof(JsonStringEnumConverter))]

public enum SubsicriptionType
{
    Free,
    Starter,
    Pro
}
