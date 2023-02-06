# Domain Aggregates

## Product

```csharp
class Product
{
    Product Create();
    void Update(Product product);
    // TODO: Add remaining methods
}
```

```json
{
    "id": { "value": "00000000-0000-0000-0000-000000000000" },
    "name": "The product",
    "price": 50.00,
    "serviceProductIds": [
        { "value": "00000000-0000-0000-0000-000000000000" },
    ],
    "detachedProductIds": [
        { "value": "00000000-0000-0000-0000-000000000000" },
    ],
}
```
