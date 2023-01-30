# Domain Aggregates

## ServiceAppointmet

```csharp
class ServiceAppointment
{
    ServiceAppointment Create();
    void AddDetachedProduct(DetachedProduct detachedProduct);
    void RemoveDetachedProduct(DetachedProduct detachedProduct);
    void UpdateDetachedProduct(DetachedProduct detachedProduct);
    void UpdateServiceId(ServiceId serviceId)
    // TODO: Add remaining methods
}
```

```json
{
    "id": { "value": "00000000-0000-0000-0000-000000000000" },
    "obs": "The customer has re-scheduled the appointment",
    "detachedProducts": [
        {
            "id": { "value": "00000000-0000-0000-0000-000000000000" },
            "ProductId": { "value": "00000000-0000-0000-0000-000000000000" },
            "quantity": 4,
            "price": 37.5,
        }
    ],
    "CustomerId": { "value": "00000000-0000-0000-0000-000000000000" },
    "ServiceId": { "value": "00000000-0000-0000-0000-000000000000" },
    "appointmentDateTime": "2020-01-01T00:00:00.0000000Z",
    "executionDateTime": "2020-01-01T00:00:00.0000000Z"
}
```
