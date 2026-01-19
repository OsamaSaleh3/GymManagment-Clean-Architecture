using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagment.Contracts.Subsicription;

public record CreatesubsicriptionRequest(SubsicriptionType subsicriptionType, Guid AdminId);
