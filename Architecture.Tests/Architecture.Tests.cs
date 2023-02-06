using FluentAssertions;
using NetArchTest.Rules;

namespace Architecture.Tests;

public class ArchitectureTests
{
    private const string DomainNamespace = "Domain";
    private const string ApplicationNamespace = "Application";
    private const string InfrastructureNamespace = "Infra";
    private const string ContractsNamespace = "Contracts";
    private const string ApiNamespace = "Api";

    [Fact]
    public void Domain_Should_Not_HaveDependencyOnOtherProjects()
    {
        // Arrange
        var assembly = typeof(ZoomMap.Domain.AssemblyReference).Assembly;


        var otherProjects = new[]
        {
            ApplicationNamespace,
            InfrastructureNamespace,
            ContractsNamespace,
            ApiNamespace
        };

        // Act
        var result = Types.InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAll(otherProjects)
            .GetResult();

        // Assert
        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Application_Should_Not_HaveDependencyOnOtherProjects()
    {
        // Arrange
        var assembly = typeof(ZoomMap.Application.AssemblyReference).Assembly;

        var otherProjects = new[]
        {
            InfrastructureNamespace,
            ContractsNamespace,
            ApiNamespace
        };

        // Act
        var result = Types.InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAll(otherProjects)
            .GetResult();

        // Assert
        result.IsSuccessful.Should().BeTrue();
    }

    //[Fact]
    //public void Handlers_Should_Have_DependencyOnDomain()
    //{
    //    // Arrange
    //    var assembly = typeof(ZoomMap.Application.AssemblyReference).Assembly;

    //    // Act
    //    var result = Types
    //        .InAssembly(assembly)
    //        .That()
    //        .HaveNameEndingWith("Handler")
    //        .Should()
    //        .HaveDependencyOn(DomainNamespace)
    //        .GetResult();

    //    // Assert
    //    result.IsSuccessful.Should().BeTrue();
    //}

    [Fact]
    public void Infrastructure_Should_Not_HaveDependencyOnOtherProjects()
    {
        // Arrange
        var assembly = typeof(ZoomMap.Infra.AssemblyReference).Assembly;

        var otherProjects = new[]
        {
            ContractsNamespace,
            ApiNamespace
        };

        // Act
        var result = Types.InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAll(otherProjects)
            .GetResult();

        // Assert
        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Contracts_Should_Not_HaveDependencyOnOtherProjects()
    {
        // Arrange
        var assembly = typeof(ZoomMap.Contracts.AssemblyReference).Assembly;

        var otherProjects = new[]
        {
            ApplicationNamespace,
            InfrastructureNamespace,
            DomainNamespace,
            ApiNamespace
        };

        // Act
        var result = Types.InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAll(otherProjects)
            .GetResult();

        // Assert
        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Presentation_Should_Not_HaveDependencyOnOtherProjects()
    {
        // Arrange
        var assembly = typeof(ZoomMap.Api.AssemblyReference).Assembly;

        var otherProjects = new[]
        {
            InfrastructureNamespace,
            DomainNamespace,
        };

        // Act
        var result = Types.InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAll(otherProjects)
            .GetResult();

        // Assert
        result.IsSuccessful.Should().BeTrue();
    }
}
