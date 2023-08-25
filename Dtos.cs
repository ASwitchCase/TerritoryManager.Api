using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TerritoryManager.Api.Models;

namespace TerritoryManager.Api;

public record TerritoryDto(
    string tid,
    Publisher publisher,
    string dateAssigned,
    string driveLink
);

public record TerritoryUpdateDto(
    Publisher publisher,
    string dateAssigned
);

public record UserAddDto(
    string username,
    string password
);

