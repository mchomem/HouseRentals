﻿namespace HouseRentals.Domain.Entities;

/// <summary>
/// Representa um inquilino que aluga uma casa.
/// </summary>
public class Tenant : BaseEntity
{
    private Tenant() { }

    public Tenant(string fullName, string email, string phoneNumber, DateTime birthDate)
    {
        CheckIfMinor(birthDate);

        FullName = fullName;
        Email = email;
        PhoneNumber = phoneNumber;
        BirthDate = birthDate;
    }

    public string FullName { get; private set; }
    public string Email { get; private set; }
    public string PhoneNumber { get; private set; }
    public DateTime BirthDate { get; private set; }
    public bool Deleted { get; private set; }

    public ICollection<Rental> Rentals { get; private set; }

    public void Update(string fullName, string email, string phoneNumber, DateTime birthDate)
    {
        CheckIfMinor(birthDate);

        FullName = fullName;
        Email = email;
        PhoneNumber = phoneNumber;
        BirthDate = birthDate;
    }

    public void Delete()
        => Deleted = true;

    private void CheckIfMinor(DateTime birthDate)
    {
        if (DateTime.Now.Year - birthDate.Year < 18)
            throw new TenantException(DefaultMessages.TenantMustBeAtLeast18YearsOld);
    }
}
