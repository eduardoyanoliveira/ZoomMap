# Domain Aggregates

## Service

```csharp
class Service
{
    Service Create();
    void AddServiceProduct(ServiceProduct serviceProduct);
    void RemoveServiceProduct(ServiceProduct serviceProduct);
    void UpdateServiceProduct(ServiceProduct serviceProduct);
    // TODO: Add remaining methods
}
```

```json
{
    "id": { "value": "00000000-0000-0000-0000-000000000000" },
    "name": "Test Service",
    "servicePrice": 100.00,
    "serviceProducts": [
        {
            "id": { "value": "00000000-0000-0000-0000-000000000000" },
            "ProductId": { "value": "00000000-0000-0000-0000-000000000000" },
            "quantity": 9,
            "price": 40.75,
        }
    ],
}
```
