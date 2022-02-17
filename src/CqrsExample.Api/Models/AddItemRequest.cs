namespace CqrsExample.Api.Models;

public record AddItemRequest(string ProductId, int Quantity);