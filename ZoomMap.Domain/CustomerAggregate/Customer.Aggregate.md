# Domain Aggregates

## Customer

```csharp
class Customer
{
    Customer Create();
    void Update(Customer customer);
    // TODO: Add remaining methods
}
```

```json
{
    "id": { "value": "00000000-0000-0000-0000-000000000000" },
    "name": "Jhon",
    "surname": "Smith",
    "birthDate": "1998-10-12T00:00:00.0000000Z",
    "email": "jhomsmith@server.com",
    "contractIds": [
        { "value": "00000000-0000-0000-0000-000000000000" },
    ],
    "serviceappointmentIds": [
        { "value": "00000000-0000-0000-0000-000000000000" },
    ],
}
```
