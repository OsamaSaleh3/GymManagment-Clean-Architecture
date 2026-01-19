using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagment.Contracts.Subsicription;

public record CreatesubscriptionRequest(SubscriptionType subsicriptionType, Guid AdminId);
