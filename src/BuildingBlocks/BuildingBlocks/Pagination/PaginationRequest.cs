﻿namespace BuildingBlocks.Pagination;

public record PaginationRequest(int PageIndex = 0, int PageSize = 10, string? SearchString = null);
