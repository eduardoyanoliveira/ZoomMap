# Domain Aggregates

## Contract

```csharp
class Contract
{
    Contract Create();
    void AddServiceAppointment(ServiceAppointment serviceAppointment);
    void RemoveServiceAppointment(ServiceAppointment serviceAppointment);
    // TODO: Add remaining methods
}
```

```json
{
    "id": { "value": "00000000-0000-0000-0000-000000000000" },
    "number": 1,

    "SellerId": { "value": "00000000-0000-0000-0000-000000000000" },
    "CustomerId": { "value": "00000000-0000-0000-0000-000000000000" },

    "ServiceAppointmentIds": [
        { "value": "00000000-0000-0000-0000-000000000000" }
    ],

    "startDateTime": "2020-01-01T00:00:00.0000000Z",
    "endDateTime": "2022-01-01T00:00:00.0000000Z",
    "programmedEndDateTime": "2021-01-01T00:00:00.0000000Z",
}
```
