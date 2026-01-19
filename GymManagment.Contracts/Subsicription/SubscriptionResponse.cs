using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagment.Contracts.Subsicription;

public record SubscriptionResponse(Guid Id, SubscriptionType subsicriptionType);

