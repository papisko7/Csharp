using MvcApp.DTOs.Group_DTOs;
using MvcApp.Tests.Infrastructure;
using System.Net;
using System.Net.Http.Json;

namespace MvcApp.Tests.Integration;

public class GroupsControllerTests : IClassFixture<CustomWebApplicationFactory>
{
	private readonly HttpClient _client;

	public GroupsControllerTests(CustomWebApplicationFactory factory)
	{
		_client = factory.CreateClient();
	}

	[Fact]
	public async Task GetGroups_WhenDatabaseHasSeedData_ReturnsOkAndPopulatedList()
	{
		// Act
		var response = await _client.GetAsync("/api/groups");

		// Assert
		Assert.Equal(HttpStatusCode.OK, response.StatusCode);
		var groups = await response.Content.ReadFromJsonAsync<List<GroupDto>>();
		Assert.NotNull(groups);
		Assert.NotEmpty(groups);
	}

	[Fact]
	public async Task GetGroupWithStudents_WhenGroupExists_ReturnsOkAndPopulatedStudentsList()
	{
		// Arrange
		int existingGroupId = 1;

		// Act
		var response = await _client.GetAsync($"/api/groups/{existingGroupId}/students");

		// Assert
		Assert.Equal(HttpStatusCode.OK, response.StatusCode);
		var groupWithStudents = await response.Content.ReadFromJsonAsync<GroupWithStudentsDto>();
		Assert.NotNull(groupWithStudents);
		Assert.Equal(existingGroupId, groupWithStudents.GroupId);
		Assert.NotEmpty(groupWithStudents.Students);
	}

	[Fact]
	public async Task PostGroup_WhenPayloadIsValid_ReturnsCreatedAndSavesToDatabase()
	{
		// Arrange
		var newGroup = new GroupDto
		{
			Name = "Wydział Architektury IT"
		};

		// Act
		var response = await _client.PostAsJsonAsync("/api/groups", newGroup);

		// Assert
		Assert.Equal(HttpStatusCode.Created, response.StatusCode);
		var createdGroup = await response.Content.ReadFromJsonAsync<GroupDto>();
		Assert.NotNull(createdGroup);
		Assert.True(createdGroup.GroupId > 0);
		Assert.Equal("Wydział Architektury IT", createdGroup.Name);
	}

	[Fact]
	public async Task PutGroup_WhenIdMismatch_ReturnsBadRequest()
	{
		// Arrange
		int urlId = 99;
		var dto = new GroupDto { GroupId = 1, Name = "Zmiana Nazwy" };

		// Act
		var response = await _client.PutAsJsonAsync($"/api/groups/{urlId}", dto);

		// Assert
		Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
	}

	[Fact]
	public async Task DeleteGroup_WhenGroupExists_ReturnsNoContentAndRemovesFromDatabase()
	{
		// Arrange 
		var groupToDelete = new GroupDto { Name = "Grupa Widmo" };
		var postRes = await _client.PostAsJsonAsync("/api/groups", groupToDelete);
		var created = await postRes.Content.ReadFromJsonAsync<GroupDto>();

		// Act
		var response = await _client.DeleteAsync($"/api/groups/{created.GroupId}");

		// Assert
		Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);

		var getRes = await _client.GetAsync($"/api/groups/{created.GroupId}");
		Assert.Equal(HttpStatusCode.NotFound, getRes.StatusCode);
	}

	[Fact]
	public async Task GetGroup_WhenIdDoesNotExist_ReturnsNotFound()
	{
		// Arrange
		int nonExistentGroupId = 888888;

		// Act
		var response = await _client.GetAsync($"/api/groups/{nonExistentGroupId}/students");

		// Assert
		Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
	}

	[Fact]
	public async Task PostGroup_WhenNameIsEmpty_ReturnsBadRequest()
	{
		// Arrange 
		var invalidGroup = new GroupDto { Name = "" };

		// Act
		var response = await _client.PostAsJsonAsync("/api/groups", invalidGroup);

		// Assert
		Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
	}
}