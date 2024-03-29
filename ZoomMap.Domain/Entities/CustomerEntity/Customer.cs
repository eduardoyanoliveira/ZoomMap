﻿using ZoomMap.Domain.Common.Models;
using ZoomMap.Domain.Common.ValueObjects.AddressValueObject;
using ZoomMap.Domain.Common.ValueObjects.CPFValueObject;
using ZoomMap.Domain.Entities.CustomerEntity.ValueObjects;

namespace ZoomMap.Domain.Entities.CustomerEntity
{
    public sealed class Customer : AggregateRoot<CustomerId>
    {
        public CPF CPF { get; }
        public string Name { get; }
        public string Surname { get; }
        public DateTime BirthDate { get; }
        public string Email { get; }
        public Address Address { get; }

        private Customer(
            CustomerId customerId,
            CPF cpf,
            string name,
            string surname,
            DateTime birthDate,
            string email,
            Address address
        )
            : base(customerId)
        {
            CPF = cpf;
            Name = name;
            Surname = surname;
            BirthDate = birthDate;
            Email = email;
            Address = address;
        }

        public static Customer Create(
            CPF cpf,
            string name,
            string surname,
            DateTime birthDate,
            string email,
            Address address
        )
        {
            return new Customer(
               CustomerId.CreateUnique(),
               cpf,
               name,
               surname,
               birthDate,
               email,
               address
            );
        }
    }
}
